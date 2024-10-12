using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cortside.AspNetCore.Auditable.Entities;
using Cortside.Common.Validation;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Exceptions;

namespace RecipeBox.Domain.Entities {
    [Index(nameof(RecipeResourceId), IsUnique = true)]
    [Table("Recipe")]
    [Comment("Recipes")]
    public class Recipe : AuditableEntity {
        protected Recipe() {
            // Required by EF as it doesn't know about User
        }

        public Recipe(string name, string description, List<Tag> tags, List<Ingredient> ingredients) {
            RecipeResourceId = Guid.NewGuid();
            Name = name;
            Description = description;
            Tags = tags;
            AddIngredients(ingredients);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Primary Key")]
        public int RecipeId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeResourceId { get; private set; }

        [MaxLength(50)]
        public string Name { get; private set; }

        [MaxLength(500)]
        public string Description { get; private set; }

        public List<Tag> Tags { get; private set; }

        // expose items as a read only collection so that the collection cannot be manipulated without going through Recipe
        private readonly List<Ingredient> ingredients = new List<Ingredient>();
        public virtual IReadOnlyList<Ingredient> Ingredients => ingredients;

        public void AddIngredient(Ingredient ingredient) {
            var recipeIngredient = ingredients.Find(x => x.IngredientId == ingredient.IngredientId);
            Guard.Against(() => recipeIngredient != null, () => throw new InvalidIngredientMessage("Ingredient already exists on recipe."));
            ingredients.Add(ingredient);
        }

        private void AddIngredients(List<Ingredient> ingredients) {
            foreach (var ingredient in ingredients) {
                AddIngredient(ingredient);
            }
        }

        public void RemoveIngredient(Ingredient ingredient) {
            ingredients.Remove(ingredient);
        }

        public void RemoveIngredients(List<Ingredient> ingredientsToRemove) {
            Guard.Against(() => ingredientsToRemove == null || ingredientsToRemove.Count == 0, () => throw new InvalidIngredientMessage("Ingredients to remove must not be null and have ingredients"));
            foreach (var item in ingredientsToRemove) {
                Guard.Against(() => item == null || !ingredients.Contains(item), () => throw new InvalidIngredientMessage("Ingredient to remove must not be null and must be part of Recipe"));
            }

            foreach (var ingredient in ingredientsToRemove) {
                ingredients.Remove(ingredient);
            }
        }

        public void UpdateRecipe(Recipe recipe) {
            Name = recipe.Name;
            Description = recipe.Description;
            RemoveIngredients(ingredients);
            AddIngredients(recipe.ingredients);

        }
    }
}

