using System;
using Cortside.AspNetCore.Common.Dtos;

namespace RecipeBox.Dto {
    public class RecipeIngredientDto : AuditableEntityDto {
        public int RecipeIngredientId { get; set; }

        public Guid RecipeIngredientResourceId { get; set; }

        public RecipeDto Recipe { get; set; }
        public IngredientDto Ingredient { get; set; }
        public decimal Quantity { get; set; }
    }
}
