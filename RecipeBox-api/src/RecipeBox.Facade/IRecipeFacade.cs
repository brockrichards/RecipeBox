using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Dto;

namespace RecipeBox.Facade {
    public interface IRecipeFacade {
        Task<RecipeDto> CreateRecipeAsync(RecipeDto input);
        Task<RecipeDto> GetRecipeAsync(Guid id);
        Task<PagedList<RecipeDto>> SearchRecipesAsync(RecipeSearchDto search);
        Task<RecipeDto> UpdateRecipeAsync(Guid id, RecipeDto dto);
        Task<RecipeDto> AddRecipeIngredientAsync(Guid id, IngredientDto dto);
    }
}

