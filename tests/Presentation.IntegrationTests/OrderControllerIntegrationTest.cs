using Application.InputModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;

namespace Presentation.IntegrationTests;

public class OrderControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private const string _jsonMediaType = "application/json";
    private readonly HttpClient _httpClient;

    public OrderControllerIntegrationTest(WebApplicationFactory<Program> application)
    {
        _httpClient = application.CreateClient();
    }

    [Fact]
    public async Task CreateOrder()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Created;

        var requestBody = new OrderInputModel()
        {
            Items = [
                new OrderItemInputModel
                {
                    Amount = 1,
                    KitchenAreaName = "Drink",
                    Name = "Water"
                }
            ]
        };

        // Act.
        var response = await _httpClient.PostAsync("/Order", new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, _jsonMediaType));

        Assert.Equal(expectedStatusCode, response.StatusCode);
        Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);
    }
}