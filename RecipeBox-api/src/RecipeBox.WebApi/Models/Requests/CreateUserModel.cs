namespace RecipeBox.WebApi.Models.Requests {
    /// <summary>
    /// Request information to create a new User
    /// </summary>
    public class CreateUserModel {
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

