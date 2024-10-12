using System.Collections.Generic;

namespace RecipeBox.Dto {
    public class RecipeSearchDto {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TagDto> Tags { get; set; }

        public List<IngredientDto> Ingredients { get; set; }
    }
}
