using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HelloWorldApi;
using HelloWorldApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace HelloWorldApiTest
{
    public class HelloWorldControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HelloWorldControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Request_Get_HelloWorld_Returns_HelloWorldAsync()
        {
            // Arrange
            const string url = "api/v1/helloworld";

            // Act
            HttpResponseMessage response = await _client.GetAsync(url);
            string responseContent = await response.Content.ReadAsStringAsync();
            HelloWorldResponse helloWorldResponse = JsonConvert.DeserializeObject<HelloWorldResponse>(responseContent);

            // Assert
            response.EnsureSuccessStatusCode();
            helloWorldResponse.Text.ShouldBe("Hello World!");
        }

        [Theory]
        [InlineData("Nazar")]
        [InlineData("Taras")]
        [InlineData("Vova")]
        [InlineData("Kolya")]
        public async Task Request_Post_MyName_Returns_MyName_Greeting(string name)
        {
            // Arrange
            const string url = "api/v1/helloworld/greet";
            HelloWorldRequest helloWorldRequest = new()
            {
                Name = name
            };
            JsonContent postContent = JsonContent.Create(helloWorldRequest);

            // Act
            HttpResponseMessage response = await _client.PostAsync(url, postContent);
            string responseContent = await response.Content.ReadAsStringAsync();
            HelloWorldResponse helloWorldResponse = JsonConvert.DeserializeObject<HelloWorldResponse>(responseContent);

            // Assert
            response.EnsureSuccessStatusCode();
            helloWorldResponse.Text.ShouldBe($"Hi, {helloWorldRequest.Name}!");
        }
    }
}
