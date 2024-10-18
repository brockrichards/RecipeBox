using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using RecipeBox.Data.Repositories;
using RecipeBox.DomainService;
using RecipeBox.Dto;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.Facade {
    public class TagFacade : ITagFacade {
        private readonly IUnitOfWork uow;
        private readonly ITagService tagService;
        private readonly ITagRepository tagRepository;
        private readonly TagMapper mapper;

        public TagFacade(IUnitOfWork uow, ITagService tagService, ITagRepository tagRepository, TagMapper mapper) {
            this.uow = uow;
            this.tagService = tagService;
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }

        public async Task<TagDto> GetTagAsync(Guid id) {
            // Using BeginNoTracking on GET endpoints for a single entity so that data is read committed
            // with assumption that it might be used for changes in future calls
            await using (var tx = uow.BeginNoTracking()) {
                var tag = await tagRepository.GetAsync(id).ConfigureAwait(false);

                return mapper.MapToDto(tag);
            }
        }

        public async Task<PagedList<TagDto>> SearchTagsAsync(TagSearchDto search) {
            // Using BeginReadUncommittedAsync on GET endpoints that return a list, this will read uncommitted and
            // as notracking in ef core.  this will result in a non-blocking dirty read, which is accepted best practice for mssql
            await using (var tx = await uow.BeginReadUncommitedAsync().ConfigureAwait(false)) {
                var tags = await tagRepository.SearchAsync(mapper.Map(search)).ConfigureAwait(false);

                var results = new PagedList<TagDto> {
                    PageNumber = tags.PageNumber,
                    PageSize = tags.PageSize,
                    TotalItems = tags.TotalItems,
                    Items = tags.Items.ConvertAll(x => mapper.MapToDto(x))
                };

                return results;
            }
        }

        public async Task<TagDto> CreateTagAsync(TagDto dto) {
            var tag = tagService.CreateTag(dto);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(tag);
        }

        public async Task<TagDto> UpdateTagAsync(Guid id, TagDto dto) {
            var tag = await tagRepository.GetAsync(id).ConfigureAwait(false);
            tag = tagService.UpdateTag(tag, dto);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(tag);
        }
    }
}

