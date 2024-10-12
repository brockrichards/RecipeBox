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

        public static Recipe GetRecipeEntity(string name = null, string description = null, List<Ingredient> ingredients = null, List<Tag> tags = null) {
            name ??= RandomValues.CreateRandomString();
            description ??= RandomValues.CreateRandomString();
            ingredients ??= new List<Ingredient> { GetIngredientEntity() };
            tags ??= new List<Tag> { GetTagEntity() };
            return new Recipe(name, description, tags, ingredients);
        }

        public static Ingredient GetIngredientEntity(string name = null) {
            return new Ingredient(name ?? RandomValues.CreateRandomString());
        }
    }
}

