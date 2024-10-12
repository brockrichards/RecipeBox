using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;

namespace RecipeBox.Data.Repositories {
    public interface IRecipeRepository {
        Task<PagedList<Recipe>> SearchAsync(IRecipeSearch model);
        Task<Recipe> AddAsync(Recipe recipe);
        Task<Recipe> GetAsync(Guid id);
        void RemoveIngredients(List<Ingredient> ingredientsToRemove);
    }
}

