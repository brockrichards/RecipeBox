using System.ComponentModel.DataAnnotations;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request create a new unit
    /// </summary>
    public class CreateUnitModel {
        /// <summary>
        /// Gets or sets the unit name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unit category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [Required]
        public string Description { get; set; }
    }
}

