using System.Collections.Generic;
using Cortside.Common.Testing;
using RecipeBox.Domain.Entities;

namespace RecipeBox.TestUtilities {
    public class EntityBuilder {
        public static User GetUserEntity() {
            return new User(RandomValues.FirstName, RandomValues.LastName, ModelBuilder.GetEmail());
        }

        public static Tag GetTagEntity() {
            return new Tag(RandomValues.CreateRandomString());
        }

        public static Recipe GetRecipeEntity(string name = null, string description = null, bool isPublic = false, string imageUrl = null, List<Ingredient> ingredients = null, List<Tag> tags = null) {
            name ??= RandomValues.CreateRandomString();
            description ??= RandomValues.CreateRandomString();
            ingredients ??= new List<Ingredient> { GetIngredientEntity() };
            tags ??= new List<Tag> { GetTagEntity() };
            Recipe recipe = new Recipe(name, description, isPublic, imageUrl);
            if(ingredients != null) {
                recipe.AddIngredients(ingredients);
            }
            if (tags != null) {
                recipe.AddTags(tags);
            }
            return recipe;
        }

        public static Ingredient GetIngredientEntity(string name = null) {
            return new Ingredient(name ?? RandomValues.CreateRandomString());
        }
    }
}

