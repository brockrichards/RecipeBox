using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using RecipeBox.Data.Repositories;
using RecipeBox.DomainService;
using RecipeBox.Dto;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.Facade {
    public class RecipeFacade : IRecipeFacade {
        private readonly IUnitOfWork uow;
        private readonly IRecipeService recipeService;
        private readonly IRecipeRepository recipeRepository;
        private readonly RecipeMapper mapper;

        public RecipeFacade(IUnitOfWork uow, IRecipeService recipeService, IRecipeRepository recipeRepository, RecipeMapper mapper) {
            this.uow = uow;
            this.recipeService = recipeService;
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }

        public async Task<RecipeDto> GetRecipeAsync(Guid id) {
            // Using BeginNoTracking on GET endpoints for a single entity so that data is read committed
            // with assumption that it might be used for changes in future calls
            await using (var tx = uow.BeginNoTracking()) {
                var recipe = await recipeRepository.GetAsync(id).ConfigureAwait(false);

                return mapper.MapToDto(recipe);
            }
        }

        public async Task<PagedList<RecipeDto>> SearchRecipesAsync(RecipeSearchDto search) {
            // Using BeginReadUncommittedAsync on GET endpoints that return a list, this will read uncommitted and
            // as notracking in ef core.  this will result in a non-blocking dirty read, which is accepted best practice for mssql
            await using (var tx = await uow.BeginReadUncommitedAsync().ConfigureAwait(false)) {
                var recipes = await recipeRepository.SearchAsync(mapper.Map(search)).ConfigureAwait(false);

                var results = new PagedList<RecipeDto> {
                    PageNumber = recipes.PageNumber,
                    PageSize = recipes.PageSize,
                    TotalItems = recipes.TotalItems,
                    Items = recipes.Items.ConvertAll(x => mapper.MapToDto(x))
                };

                return results;
            }
        }

        public async Task<RecipeDto> CreateRecipeAsync(RecipeDto dto) {
            var recipe = await recipeService.CreateRecipeAsync(dto).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(recipe);
        }

        public async Task<RecipeDto> UpdateRecipeAsync(Guid id, RecipeDto dto) {
            var recipe = await recipeRepository.GetAsync(id).ConfigureAwait(false);
            recipe = await recipeService.UpdateRecipeAsync(recipe, dto).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(recipe);
        }
    }
}

