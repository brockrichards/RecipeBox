using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RecipeBox.Data;
using RecipeBox.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace RecipeBox.WebApi.IntegrationTests.Tests {
    public class UserTest : IClassFixture<IntegrationFixture> {
        private readonly IntegrationFixture fixture;
        private readonly HttpClient testServerClient;

        public UserTest(IntegrationFixture fixture, ITestOutputHelper output) {
            this.fixture = fixture;
            this.fixture.TestOutputHelper = output;
            testServerClient = fixture.CreateAuthorizedClient("api");
        }

        [Fact]
        public async Task ShouldCreateUserAsync() {
            //arrange
            var request = ModelBuilder.GetUpdateUserModel();
            var requestBody = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //act
            var response = await testServerClient.PostAsync("/api/v1/Users", requestBody);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var content = await response.Content.ReadAsStringAsync();
            var User = JsonConvert.DeserializeObject<Models.Responses.UserModel>(content);
            Assert.Equal(request.UserName, User.UserName);
            Assert.Equal(request.Email, User.Email);
        }

        [Fact]
        public async Task ShouldGetUserAsync() {
            //arrange
            var db = fixture.NewScopedDbContext<DatabaseContext>();
            var id = db.Users.First().UserResourceId;

            //act
            var response = await testServerClient.GetAsync($"api/v1/Users/{id}");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

