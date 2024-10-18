using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface IRecipeRepository {
        Task<PagedList<Recipe>> SearchAsync(IRecipeSearch model);
        Task<Recipe> AddAsync(Recipe recipe);
        Task<Recipe> GetAsync(Guid id);
        void Update(Recipe recipe);
        void Delete(Recipe recipe);
        Task<RecipeIngredient> GetRecipeIngredientAsync(Recipe recipe, Guid ingredientResourceId, Guid unitResourceId, decimal quantity);
        Task<RecipeTag> GetRecipeTagAsync(Recipe recipe, Guid tagResourceId);
    }
}

