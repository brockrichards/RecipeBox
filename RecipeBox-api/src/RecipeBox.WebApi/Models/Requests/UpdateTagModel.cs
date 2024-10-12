using System;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request to update a tag
    /// </summary>
    public class UpdateTagModel {
        /// <summary>
        /// Gets the tag resource id.
        /// </summary>
        /// <value>
        /// The resource id.
        /// </value>
        public Guid TagResourceId { get; set; }
        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}

