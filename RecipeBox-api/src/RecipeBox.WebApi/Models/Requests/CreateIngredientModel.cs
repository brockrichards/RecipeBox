using System.ComponentModel.DataAnnotations;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request to create an ingredient
    /// </summary>
    public class CreateIngredientModel {
        /// <summary>
        /// Ingredient name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [Required]
        public string Name { get; set; }
    }
}

