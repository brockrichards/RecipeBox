using System.Linq;
using System.Threading.Tasks;
using Cortside.DomainEvent.EntityFramework;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeBox.Data;
using RecipeBox.Data.Repositories;
using RecipeBox.TestUtilities;
using Xunit;

namespace RecipeBox.DomainService.Tests {
    public class UserServiceTest : DomainServiceTest<UserService> {
        private readonly DatabaseContext databaseContext;

        public UserServiceTest() : base() {
            databaseContext = GetDatabaseContext();

            var publisher = new Mock<IDomainEventOutboxPublisher>();
            var UserRepository = new UserRepository(databaseContext);
            Service = new UserService(UserRepository, publisher.Object, NullLogger<UserService>.Instance);
        }

        [Fact]
        public async Task ShouldCreateUserAsync() {
            // Arrange
            var dto = DtoBuilder.GetUserDto();

            // Act
            await Service.CreateUserAsync(dto);
            await databaseContext.SaveChangesAsync();

            // Assert
            Assert.True(databaseContext.Users.Any(x => x.UserName == dto.UserName));
        }
    }
}

