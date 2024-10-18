using System.Threading.Tasks;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public interface IRecipeService {
        Task<Recipe> CreateRecipeAsync(RecipeDto dto);
        Task<Recipe> UpdateRecipeAsync(Recipe recipe, RecipeDto dto);
    }
}

