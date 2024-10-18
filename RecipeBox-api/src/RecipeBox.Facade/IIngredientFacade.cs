using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.Common.Paging;
using RecipeBox.Dto;

namespace RecipeBox.Facade {
    public interface IIngredientFacade {
        Task<IngredientDto> CreateIngredientAsync(IngredientDto dto);
        Task<IngredientDto> GetIngredientAsync(Guid id);
        Task<PagedList<IngredientDto>> SearchIngredientsAsync(IngredientSearchDto search);
        Task<IngredientDto> UpdateIngredientAsync(Guid id, IngredientDto dto);
    }
}

