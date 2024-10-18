using System;

namespace RecipeBox.Dto {
    public class RecipeIngredientDto {
        public Guid IngredientResourceId { get; set; }
        public UnitDto Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
