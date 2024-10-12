using FluentAssertions;
using RecipeBox.TestUtilities;
using Xunit;

namespace RecipeBox.Domain.Tests {
    public class UserTest {
        [Fact]
        public void ShouldUpdateUser() {
            // Arrange
            var User = EntityBuilder.GetUserEntity();

            // Act
            User.Update("elmer", "elmer@fudd.org", "wabbitHunter");

            // Assert
            User.UserName.Should().Be("elmerfudd");
            User.Email.Should().Be("elmer@fudd.org");
        }
    }
}

