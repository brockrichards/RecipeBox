using System.ComponentModel.DataAnnotations;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request create a new tag
    /// </summary>
    public class CreateTagModel {
        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }
    }
}

