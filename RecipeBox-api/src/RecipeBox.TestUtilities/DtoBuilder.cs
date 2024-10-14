using Cortside.Common.Testing;
using RecipeBox.Dto;

namespace RecipeBox.TestUtilities {
    public class DtoBuilder {
        public static UserDto GetUserDto() {
            return new UserDto() {
                UserName = RandomValues.FirstName,
                Email = ModelBuilder.GetEmail()
            };
        }

        public static RecipeDto GetRecipeDto() {
            return new RecipeDto() {
                RecipeTags = [],
                RecipeIngredients = []
            };
        }
    }
}

