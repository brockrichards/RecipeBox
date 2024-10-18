using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public interface IIngredientService {
        Ingredient CreateIngredient(IngredientDto dto);
        Ingredient UpdateIngredient(Ingredient ingredient, IngredientDto dto);
    }
}

