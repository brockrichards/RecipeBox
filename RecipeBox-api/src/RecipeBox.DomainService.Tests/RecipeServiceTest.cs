using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeBox.Data;
using RecipeBox.Data.Repositories;
using RecipeBox.TestUtilities;
using Xunit;

namespace RecipeBox.DomainService.Tests {
    public class RecipeServiceTest : DomainServiceTest<IRecipeService> {
        private readonly DatabaseContext databaseContext;

        public RecipeServiceTest() : base() {
            databaseContext = GetDatabaseContext();
            var RecipeRepository = new RecipeRepository(databaseContext);
            Service = new RecipeService(RecipeRepository, NullLogger<RecipeService>.Instance);

            var name = Guid.NewGuid().ToString();
            var User = EntityBuilder.GetUserEntity();
            databaseContext.Users.Add(User);
            databaseContext.SaveChanges(true);
        }

        [Fact]
        public async Task ShouldCreateRecipeAsync() {
            // Arrange
            var recipe = DtoBuilder.GetRecipeDto();

            // Act
            await Service.CreateRecipeAsync(recipe);
            await databaseContext.SaveChangesAsync();

            // Assert
            Assert.True(databaseContext.Recipes.Any(x => x.Title == recipe.Title));
        }
    }
}

