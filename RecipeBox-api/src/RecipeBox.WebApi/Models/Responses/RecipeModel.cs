using System;
using System.Collections.Generic;
using Cortside.AspNetCore.Common.Models;
using RecipeBox.Enumerations;

namespace RecipeBox.WebApi.Models.Responses {
    /// <summary>
    /// Represents a single order
    /// </summary>
    public class RecipeModel : AuditableEntityModel {
        /// <summary>
        /// Gets or sets the order resource identifier.
        /// </summary>
        /// <value>
        /// The order resource identifier.
        /// </value>
        public Guid RecipeResourceId { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public RecipeStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        /// <value>
        /// The User.
        /// </value>
        public UserModel User { get; set; }
        /// <summary>
        /// Gets or sets the Tag.
        /// </summary>
        /// <value>
        /// The Tag.
        /// </value>
        public TagModel Tag { get; set; }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<IngredientModel> Items { get; set; }
    }
}

