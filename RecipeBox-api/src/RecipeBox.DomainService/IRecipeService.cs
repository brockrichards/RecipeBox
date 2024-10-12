using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Data.Searches;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public interface IRecipeService {
        Task<Recipe> CreateRecipeAsync(RecipeDto dto);
        Task<Recipe> GetRecipeAsync(Guid RecipeResourceId);
        Task<PagedList<Recipe>> SearchRecipesAsync(RecipeSearch search);
        Task<Recipe> UpdateRecipeAsync(Guid resourceId, RecipeDto dto);
        Task<Recipe> AddRecipeIngredientAsync(Guid resourceId, IngredientDto dto);
    }
}

