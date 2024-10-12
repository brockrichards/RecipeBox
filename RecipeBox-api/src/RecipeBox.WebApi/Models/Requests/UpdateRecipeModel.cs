using System;
using System.Collections.Generic;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request information to update a recipe
    /// </summary>
    public class UpdateRecipeModel {
        /// <summary>
        /// Gets the resource id.
        /// </summary>
        /// <value>
        /// The resource id.
        /// </value>
        public Guid RecipeResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Tags.
        /// </summary>
        /// <value>
        /// The Tags.
        /// </value>
        public List<TagModel> Tag { get; set; }

        /// <summary>
        /// Gets or sets the ingredients.
        /// </summary>
        /// <value>
        /// The ingredients.
        /// </value>
        public List<CreateIngredientModel> Ingredients { get; set; }
    }
}

