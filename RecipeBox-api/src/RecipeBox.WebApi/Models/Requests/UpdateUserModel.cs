using System;

namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request information to update a User
    /// </summary>
    public class UpdateUserModel {
        /// <summary>
        /// Gets the resource id
        /// </summary>
        /// <value>
        /// The resource id
        /// </value>
        public Guid UserResourceId { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        /// <value>
        /// The user name
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        /// <value>
        /// The email address
        /// </value>
        public string Email { get; set; }
    }
}

