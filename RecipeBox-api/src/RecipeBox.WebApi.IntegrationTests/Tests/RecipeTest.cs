using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RecipeBox.Data;
using RecipeBox.Enumerations;
using RecipeBox.TestUtilities;
using RecipeBox.WebApi.Models.Responses;
using Xunit;

namespace RecipeBox.WebApi.IntegrationTests.Tests {
    public class RecipeTest : IClassFixture<IntegrationFixture> {
        private readonly IntegrationFixture fixture;
        private readonly HttpClient client;

        public RecipeTest(IntegrationFixture fixture) {
            this.fixture = fixture;
            client = fixture.CreateAuthorizedClient("api");
        }

        [Fact]
        public async Task ShouldCreateRecipeAsync() {
            //arrange
            var orderRequest = ModelBuilder.GetCreateRecipeModel();

            //act
            var orderBody = new StringContent(JsonConvert.SerializeObject(orderRequest), Encoding.UTF8, "application/json");
            var orderResponse = await client.PostAsync("/api/v1/orders", orderBody);

            //assert
            var orderContent = await orderResponse.Content.ReadAsStringAsync();
            orderResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var order = JsonConvert.DeserializeObject<RecipeModel>(orderContent);
            order.User.UserResourceId.Should().NotBeEmpty();
            order.Items.Count.Should().Be(1);
        }

        [Fact]
        public async Task ShouldCreateUserRecipeAsync() {
            //arrange
            var request = ModelBuilder.GetUpdateUserModel();
            var requestBody = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var orderRequest = ModelBuilder.GetCreateRecipeModel();

            //act
            var response = await client.PostAsync("/api/v1/Users", requestBody);
            var content = await response.Content.ReadAsStringAsync();
            var User = JsonConvert.DeserializeObject<Models.Responses.UserModel>(content);

            var orderBody = new StringContent(JsonConvert.SerializeObject(orderRequest), Encoding.UTF8, "application/json");
            var orderResponse = await client.PostAsync($"/api/v1/Users/{User.UserResourceId}/orders", orderBody);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var orderContent = await orderResponse.Content.ReadAsStringAsync();
            orderResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var order = JsonConvert.DeserializeObject<RecipeModel>(orderContent);
            order.User.UserResourceId.Should().Be(User.UserResourceId);
            order.Items.Count.Should().Be(1);
        }

        [Fact]
        public async Task ShouldGetRecipeAsync() {
            //arrange
            var db = fixture.NewScopedDbContext<DatabaseContext>();
            var order = EntityBuilder.GetRecipeEntity();
            db.Recipes.Add(order);
            await db.SaveChangesAsync();

            //act
            var response = await client.GetAsync($"api/v1/orders/{order.RecipeResourceId}");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldAddIngredientAsync() {
            //arrange
            var db = fixture.NewScopedDbContext<DatabaseContext>();
            var orderEntity = EntityBuilder.GetRecipeEntity();
            db.Recipes.Add(orderEntity);
            await db.SaveChangesAsync();

            //act
            var orderResponse = await client.GetAsync($"api/v1/orders/{orderEntity.RecipeResourceId}");

            //assert
            var orderContent = await orderResponse.Content.ReadAsStringAsync();
            orderResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var order = JsonConvert.DeserializeObject<RecipeModel>(orderContent);
            order.User.UserResourceId.Should().NotBeEmpty();
            order.RecipeResourceId.Should().NotBeEmpty();
            order.Items.Count.Should().Be(0);
            order.Status.Should().Be(RecipeStatus.Created);

            // act
            var itemRequest = ModelBuilder.GetCreateIngredientModel();
            var orderBody = new StringContent(JsonConvert.SerializeObject(itemRequest), Encoding.UTF8, "application/json");
            orderResponse = await client.PostAsync($"api/v1/orders/{orderEntity.RecipeResourceId}/items", orderBody);

            //assert
            orderContent = await orderResponse.Content.ReadAsStringAsync();
            orderResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Contains(orderEntity.RecipeResourceId.ToString(), orderContent);

            //act
            orderResponse = await client.GetAsync($"api/v1/orders/{orderEntity.RecipeResourceId}");

            //assert
            orderContent = await orderResponse.Content.ReadAsStringAsync();
            orderResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            order = JsonConvert.DeserializeObject<RecipeModel>(orderContent);
            order.User.UserResourceId.Should().NotBeEmpty();
            order.RecipeResourceId.Should().NotBeEmpty();
            order.Items.Count.Should().Be(1);
            order.Status.Should().Be(RecipeStatus.Created);
        }

        [Fact]
        public async Task ShouldGetPagedRecipesAsync() {
            //arrange
            var db = fixture.NewScopedDbContext<DatabaseContext>();
            for (int i = 0; i < 10; i++) {
                var order = EntityBuilder.GetRecipeEntity();
                db.Recipes.Add(order);
            }
            await db.SaveChangesAsync();

            //act
            var response = await client.GetAsync("api/v1/orders?pageSize=5&page=1");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}

