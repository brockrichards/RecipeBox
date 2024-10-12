using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request information to create a new recipe
    /// </summary>
    public class CreateRecipeModel {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Tag.
        /// </summary>
        /// <value>
        /// The Tag.
        /// </value>
        public TagModel Tag { get; set; }

        /// <summary>
        /// Gets or sets the ingredients.
        /// </summary>
        /// <value>
        /// The ingredients.
        /// </value>
        public List<CreateIngredientModel> Ingredients { get; set; }
    }
}

