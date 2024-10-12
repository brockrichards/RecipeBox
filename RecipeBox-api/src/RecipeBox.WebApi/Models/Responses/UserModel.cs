using System;
using Cortside.AspNetCore.Common.Models;

namespace RecipeBox.WebApi.Models.Responses {
    /// <summary>
    /// Represents a single User
    /// </summary>
    public class UserModel : AuditableEntityModel {
        /// <summary>
        /// Gets or sets the User resource identifier.
        /// </summary>
        /// <value>
        /// The User resource identifier.
        /// </value>
        public Guid UserResourceId { get; set; }
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
    }
}

