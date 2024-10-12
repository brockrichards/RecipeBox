using System;
using System.Threading.Tasks;
using Cortside.AspNetCore.EntityFramework;
using Moq;
using RecipeBox.DomainService;
using RecipeBox.TestUtilities;
using Xunit;

namespace RecipeBox.Facade.Tests {
    public class UserFacadeTest {
        [Fact]
        public async Task ShouldGetUserAsync() {
            // arrange
            var uow = new Mock<IUnitOfWork>();
            var UserService = new Mock<IUserService>();
            var facade = new UserFacade(uow.Object, UserService.Object, new Mappers.UserMapper(new Mappers.SubjectMapper()));
            var UserResourceId = Guid.NewGuid();
            UserService.Setup(x => x.GetUserAsync(UserResourceId)).ReturnsAsync(EntityBuilder.GetUserEntity());

            // act
            var User = await facade.GetUserAsync(UserResourceId);

            // assert
            Assert.NotNull(User);
        }
    }
}

