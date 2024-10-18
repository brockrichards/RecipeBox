using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RecipeBox.Data.Repositories;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public class IngredientService : IIngredientService {
        private readonly ILogger<IngredientService> logger;
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(ILogger<IngredientService> logger, IIngredientRepository ingredientRepository) {
            this.logger = logger;
            this.ingredientRepository = ingredientRepository;
        }

        public Ingredient CreateIngredient(IngredientDto dto) {
            var ingredient = new Ingredient(dto.Name, dto.Description);
            using (logger.BeginScope(new Dictionary<string, object> { ["IngredientResourceId"] = ingredient.IngredientResourceId })) {
                logger.LogInformation("Created new ingredient");
                return ingredient;
            }
        }

        public Ingredient UpdateIngredient(Ingredient ingredient, IngredientDto dto) {
            using (logger.BeginScope(new Dictionary<string, object> { ["IngredientResourceId"] = ingredient.IngredientResourceId })) {
                ingredient.Name = dto.Name;
                ingredient.Description = dto.Description;
                logger.LogInformation("Updated ingredient");
                return ingredient;
            }
        }
    }
}

