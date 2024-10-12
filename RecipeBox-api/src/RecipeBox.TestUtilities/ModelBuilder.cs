using Cortside.Common.Testing;
using RecipeBox.WebApi.Models.Requests;

namespace RecipeBox.TestUtilities {
    public class ModelBuilder {
        public static CreateRecipeModel GetCreateRecipeModel() { return new CreateRecipeModel(); }
        public static UpdateRecipeModel GetUpdateRecipeModel() { return new UpdateRecipeModel(); }

        public static CreateUserModel GetCreateUserModel() { return new CreateUserModel(); }
        public static UpdateUserModel GetUpdateUserModel() { return new UpdateUserModel(); }

        public static CreateIngredientModel GetCreateIngredientModel() { return new CreateIngredientModel(); }
        public static UpdateIngredientModel GetUpdateIngredientModel() { return new UpdateIngredientModel(); }

        public static CreateTagModel GetCreateTagModel() { return new CreateTagModel(); }
        public static UpdateTagModel GetUpdateTagModel() { return new UpdateTagModel(); }

        /// <summary>
        /// This method is needed because the random generator uses random strings for the domain extension
        /// There is a code check for adding Users that expects a limited range of domain extensions in this repository
        /// </summary>
        /// <returns></returns>
        public static string GetEmail() {
            var email = RandomValues.EmailAddress;
            return $"{email.Split('.')[0]}.com";
        }
    }
}

