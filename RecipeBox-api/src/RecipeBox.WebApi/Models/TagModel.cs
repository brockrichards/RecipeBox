using System;
using RecipeBox.Enumerations;

namespace RecipeBox.WebApi.Models {
    /// <summary>
    /// An Tag
    /// </summary>
    public class TagModel {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagModel"/> class.
        /// </summary>
        public TagModel() {
        }
        /// <summary>
        /// Gets or sets the resourceId.
        /// </summary>
        /// <value>
        /// The resourceId.
        /// </value>
        public Guid TagResourceId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public CategoryType Category { get; set; }
    }
}

