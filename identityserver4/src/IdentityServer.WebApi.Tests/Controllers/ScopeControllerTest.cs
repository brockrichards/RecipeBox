using System.Collections.Generic;
using IdentityServer.WebApi.Controllers.Scope;
using IdentityServer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IdentityServer.WebApi.Tests.Controllers {
    public class ScopeControllerTest : BaseTestFixture {

        ScopeController controller;
        Mock<IScopeService> scopeServiceMock;

        public ScopeControllerTest() {
            scopeServiceMock = new Mock<IScopeService>();
            controller = new ScopeController(scopeServiceMock.Object);
        }

        [Fact]
        public void ShouldGetAllScopes() {
            // setup
            scopeServiceMock.Setup(x => x.GetAll()).Returns(new List<string> { "scope1", "scope2", "scop3" });

            // act
            var result = controller.GetAll() as OkObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, ((List<string>)result.Value).Count);
        }
    }
}

