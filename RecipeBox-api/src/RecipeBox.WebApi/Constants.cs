#pragma warning disable CA1724 // Unused type parameters should be removed
#pragma warning disable CS1591 // Missing XML comments

namespace RecipeBox.WebApi {
    /// <summary>
    /// Constanst for webapi
    /// </summary>
    public static class Constants {
        /// <summary>
        /// Authorization constants
        /// </summary>
        public static class Authorization {
            /// <summary>
            /// Permission constants
            /// </summary>
            public static class Permissions {
                public const string CreateUser = "CreateUser";
                public const string UpdateUser = "UpdateUser";
                public const string GetUser = "GetUser";
                public const string GetUsers = "GetUsers";
                public const string PublishUser = "PublishUser";
                public const string GetRecipe = "GetRecipe";
                public const string GetRecipes = "GetRecipes";
                public const string CreateRecipe = "CreateRecipe";
                public const string UpdateRecipe = "UpdateRecipe";
                public const string PublishRecipe = "PublishRecipe";
            }
        }
    }
}

