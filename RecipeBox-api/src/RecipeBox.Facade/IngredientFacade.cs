using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using RecipeBox.Data.Repositories;
using RecipeBox.DomainService;
using RecipeBox.Dto;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.Facade {
    public class IngredientFacade : IIngredientFacade {
        private readonly IUnitOfWork uow;
        private readonly IIngredientService ingredientService;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IngredientMapper mapper;

        public IngredientFacade(IUnitOfWork uow, IIngredientService ingredientService, IIngredientRepository ingredientRepository, IngredientMapper mapper) {
            this.uow = uow;
            this.ingredientService = ingredientService;
            this.ingredientRepository = ingredientRepository;
            this.mapper = mapper;
        }

        public async Task<IngredientDto> GetIngredientAsync(Guid id) {
            // Using BeginNoTracking on GET endpoints for a single entity so that data is read committed
            // with assumption that it might be used for changes in future calls
            await using (var tx = uow.BeginNoTracking()) {
                var ingredient = await ingredientRepository.GetAsync(id).ConfigureAwait(false);

                return mapper.MapToDto(ingredient);
            }
        }

        public async Task<PagedList<IngredientDto>> SearchIngredientsAsync(IngredientSearchDto search) {
            // Using BeginReadUncommittedAsync on GET endpoints that return a list, this will read uncommitted and
            // as notracking in ef core.  this will result in a non-blocking dirty read, which is accepted best practice for mssql
            await using (var tx = await uow.BeginReadUncommitedAsync().ConfigureAwait(false)) {
                var ingredients = await ingredientRepository.SearchAsync(mapper.Map(search)).ConfigureAwait(false);

                var results = new PagedList<IngredientDto> {
                    PageNumber = ingredients.PageNumber,
                    PageSize = ingredients.PageSize,
                    TotalItems = ingredients.TotalItems,
                    Items = ingredients.Items.ConvertAll(x => mapper.MapToDto(x))
                };

                return results;
            }
        }

        public async Task<IngredientDto> CreateIngredientAsync(IngredientDto dto) {
            var ingredient = ingredientService.CreateIngredient(dto);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(ingredient);
        }

        public async Task<IngredientDto> UpdateIngredientAsync(Guid id, IngredientDto dto) {
            var ingredient = await ingredientRepository.GetAsync(id).ConfigureAwait(false);
            ingredient = ingredientService.UpdateIngredient(ingredient, dto);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(ingredient);
        }
    }
}

