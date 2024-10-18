using System.Collections.Generic;
#pragma warning disable CS1591 // Missing XML comments

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request information to create a new recipe
    /// </summary>
    public class CreateRecipeModel {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string ImageUrl { get; set; }

        public List<IngredientModel> RecipeIngredients { get; set; }
        public List<TagModel> RecipeTags { get; set; }

    }
}

