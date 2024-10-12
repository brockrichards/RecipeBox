using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using Cortside.AspNetCore.EntityFramework;
using RecipeBox.DomainService;
using RecipeBox.Dto;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.Facade {
    public class RecipeFacade : IRecipeFacade {
        private readonly IUnitOfWork uow;
        private readonly IUserService UserService;
        private readonly IRecipeService recipeService;
        private readonly RecipeMapper mapper;

        public RecipeFacade(IUnitOfWork uow, IUserService UserService, IRecipeService recipeService, RecipeMapper mapper) {
            this.uow = uow;
            this.UserService = UserService;
            this.recipeService = recipeService;
            this.mapper = mapper;
        }

        public async Task<RecipeDto> AddRecipeIngredientAsync(Guid id, IngredientDto dto) {
            var recipe = await recipeService.AddRecipeIngredientAsync(id, dto).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(recipe);
        }

        public async Task<RecipeDto> CreateRecipeAsync(RecipeDto input) {
            var recipe = await recipeService.CreateRecipeAsync(input).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(recipe);
        }

        public async Task<RecipeDto> GetRecipeAsync(Guid id) {
            // Using BeginNoTracking on GET endpoints for a single entity so that data is read committed
            // with assumption that it might be used for changes in future calls
            await using (var tx = uow.BeginNoTracking()) {
                var recipe = await recipeService.GetRecipeAsync(id).ConfigureAwait(false);

                return mapper.MapToDto(recipe);
            }
        }

        public async Task<PagedList<RecipeDto>> SearchRecipesAsync(RecipeSearchDto search) {
            // Using BeginReadUncommittedAsync on GET endpoints that return a list, this will read uncommitted and
            // as notracking in ef core.  this will result in a non-blocking dirty read, which is accepted best practice for mssql
            await using (var tx = await uow.BeginReadUncommitedAsync().ConfigureAwait(false)) {
                var recipes = await recipeService.SearchRecipesAsync(mapper.Map(search)).ConfigureAwait(false);

                var results = new PagedList<RecipeDto> {
                    PageNumber = recipes.PageNumber,
                    PageSize = recipes.PageSize,
                    TotalItems = recipes.TotalItems,
                    Items = recipes.Items.ConvertAll(x => mapper.MapToDto(x))
                };

                return results;
            }
        }

        public async Task<RecipeDto> UpdateRecipeAsync(Guid id, RecipeDto dto) {
            var recipe = await recipeService.UpdateRecipeAsync(id, dto).ConfigureAwait(false);
            await uow.SaveChangesAsync().ConfigureAwait(false);

            return mapper.MapToDto(recipe);
        }
    }
}

