using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Domain.Entities {
    public class RecipeIngredient {
        protected RecipeIngredient() {
            // Required by EF as it doesn't know about User
        }

        public RecipeIngredient(Recipe recipe, Ingredient ingredient, Unit unit, decimal quantity) {
            Recipe = recipe;
            Ingredient = ingredient;
            Unit = unit;
            Quantity = quantity;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeIngredientId { get; private set; }

        [Comment("Public unique identifier")]
        public Guid RecipeIngredientResourceId { get; private set; }

        public Recipe Recipe { get; private set; }
        public Ingredient Ingredient { get; private set; }
        public Unit Unit { get; private set; }
        public decimal Quantity { get; private set; }
    }
}
