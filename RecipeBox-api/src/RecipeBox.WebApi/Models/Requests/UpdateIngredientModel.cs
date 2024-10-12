using System;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request to update an ingredient
    /// </summary>
    public class UpdateIngredientModel {
        /// <summary>
        /// Gets the resource id
        /// </summary>
        /// <value>
        /// The resource id
        /// </value>
        public Guid IngredientResourceId { get; set; }
        /// <summary>
        /// Ingredient name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        public string Name { get; set; }
    }
}

