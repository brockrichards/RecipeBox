using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using RecipeBox.Data.Repositories;
using RecipeBox.DomainService;
using RecipeBox.Dto;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.Facade {
    public class UnitFacade : IUnitFacade {
        private readonly IUnitOfWork uow;
        private readonly IUnitService unitService;
        private readonly IUnitRepository unitRepository;
        private readonly UnitMapper mapper;

        public UnitFacade(IUnitOfWork uow, IUnitService unitService, IUnitRepository unitRepository, UnitMapper mapper) {
            this.uow = uow;
            this.unitService = unitService;
            this.unitRepository = unitRepository;
            this.mapper = mapper;
        }

        public async Task<UnitDto> GetUnitAsync(Guid id) {
            // Using BeginNoTracking on GET endpoints for a single entity so that data is read committed
            // with assumption that it might be used for changes in future calls
            await using (var tx = uow.BeginNoTracking()) {
                var unit = await unitRepository.GetAsync(id).ConfigureAwait(false);

                return mapper.MapToDto(unit);
            }
        }

        public async Task<PagedList<UnitDto>> SearchUnitsAsync(UnitSearchDto search) {
            // Using BeginReadUncommittedAsync on GET endpoints that return a list, this will read uncommitted and
            // as notracking in ef core.  this will result in a non-blocking dirty read, which is accepted best practice for mssql
            await using (var tx = await uow.BeginReadUncommitedAsync().ConfigureAwait(false)) {
                var units = await unitRepository.SearchAsync(mapper.Map(search)).ConfigureAwait(false);

                var results = new PagedList<UnitDto> {
                    PageNumber = units.PageNumber,
                    PageSize = units.PageSize,
                    TotalItems = units.TotalItems,
                    Items = units.Items.ConvertAll(x => mapper.MapToDto(x))
                };

                return results;
            }
        }

        public async Task<UnitDto> CreateUnitAsync(UnitDto dto) {
            var unit = unitService.CreateUnit(dto);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(unit);
        }

        public async Task<UnitDto> UpdateUnitAsync(Guid id, UnitDto dto) {
            var unit = await unitRepository.GetAsync(id).ConfigureAwait(false);
            unit = unitService.UpdateUnit(unit, dto);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(unit);
        }
    }
}

