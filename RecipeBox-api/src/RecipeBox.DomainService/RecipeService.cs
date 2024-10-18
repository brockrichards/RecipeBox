using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RecipeBox.Data.Repositories;
using RecipeBox.Domain.Entities;
using RecipeBox.Dto;

namespace RecipeBox.DomainService {
    public class RecipeService : IRecipeService {
        private readonly ILogger<RecipeService> logger;
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(ILogger<RecipeService> logger, IRecipeRepository recipeRepository) {
            this.logger = logger;
            this.recipeRepository = recipeRepository;
        }

        public async Task<Recipe> CreateRecipeAsync(RecipeDto dto) {
            var recipe = new Recipe(dto.Title, dto.Description, dto.IsPublic, dto.ImageUrl);
            using (logger.BeginScope(new Dictionary<string, object> { ["RecipeResourceId"] = recipe.RecipeResourceId })) {
                if (dto.RecipeIngredients != null && dto.RecipeIngredients.Count > 0) {
                    var ingredients = await AddRecipeIngredientsAsync(recipe, dto.RecipeIngredients).ConfigureAwait(false);
                    logger.LogInformation("Added {Count} ingredients to recipe", ingredients.Count);
                }
                if (dto.RecipeTags != null && dto.RecipeTags.Count > 0) {
                    var tags = await AddRecipeTagsAsync(recipe, dto.RecipeTags).ConfigureAwait(false);
                    logger.LogInformation("Added {Count} tags to recipe", tags.Count);
                }
                logger.LogInformation("Created new recipe");
                return recipe;
            }
        }

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe, RecipeDto dto) {
            using (logger.BeginScope(new Dictionary<string, object> { ["RecipeResourceId"] = recipe.RecipeResourceId })) {
                recipe.Update(dto.Title, dto.Description, dto.IsPublic, dto.ImageUrl);

                var removedIngredients = recipe.RecipeIngredients.Where(i =>
                    !dto.RecipeIngredients.Select(r => r.IngredientResourceId).Contains(i.Ingredient.IngredientResourceId)).ToList();
                var addedIngredients = dto.RecipeIngredients.Where(r =>
                    !recipe.RecipeIngredients.Select(i => i.Ingredient.IngredientResourceId).Contains(r.IngredientResourceId)).ToList();
                var removedTags = recipe.RecipeTags.Where(i =>
                    !dto.RecipeTags.Select(r => r.TagResourceId).Contains(i.Tag.TagResourceId)).ToList();
                var addedTags = dto.RecipeTags.Where(r =>
                    !recipe.RecipeTags.Select(i => i.Tag.TagResourceId).Contains(r.TagResourceId)).ToList();

                if (removedIngredients.Count > 0) {
                    RemoveRecipeIngredients(recipe, removedIngredients);
                }
                if (addedIngredients.Count > 0) {
                    await AddRecipeIngredientsAsync(recipe, addedIngredients).ConfigureAwait(false);
                }
                if (removedTags.Count > 0) {
                    RemoveRecipeTags(recipe, removedTags);
                }
                if (addedTags.Count > 0) {
                    await AddRecipeTagsAsync(recipe, addedTags).ConfigureAwait(false);
                }
                logger.LogInformation("Updated recipe");
                return recipe;
            }
        }

        private async Task<List<RecipeIngredient>> AddRecipeIngredientsAsync(Recipe recipe, List<RecipeIngredientDto> ingredients) {
            foreach (var ingredient in ingredients) {
                recipe.RecipeIngredients.Add(await recipeRepository.GetRecipeIngredientAsync(
                    recipe,
                    ingredient.IngredientResourceId,
                    ingredient.Unit.UnitResourceId,
                    ingredient.Quantity).ConfigureAwait(false));
            };
            return recipe.RecipeIngredients.ToList();
        }

        private async Task<List<RecipeTag>> AddRecipeTagsAsync(Recipe recipe, List<RecipeTagDto> tags) {
            foreach (var tag in tags) {
                await recipeRepository.GetRecipeTagAsync(recipe, tag.TagResourceId);
            };
            return recipe.RecipeTags.ToList();
        }

        private void RemoveRecipeTags(Recipe recipe, List<RecipeTag> removedTags) {
            recipe.RecipeTags.ToList().RemoveAll(r => removedTags.Select(r => r.RecipeTagId).Contains(r.RecipeTagId));
        }

        private void RemoveRecipeIngredients(Recipe recipe, List<RecipeIngredient> removedIngredients) {
            recipe.RecipeIngredients.ToList().RemoveAll(r => removedIngredients.Select(r => r.RecipeIngredientId).Contains(r.RecipeIngredientId));
        }
    }
}

