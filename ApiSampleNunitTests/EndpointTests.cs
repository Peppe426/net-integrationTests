using ApiSample.Models;
using IntegrationTests;
using IntegrationTests.Base;
using Microsoft.EntityFrameworkCore;
namespace ApiSampleNunitTests;

class EndpointTests : IntegrationTest<Program, DbContext>
{
    [Test]
    public async Task ShouldReturnSuccessStatusCodeOnGetWeatherForecast()
    {
        // Given
        var request = new HttpRequestMessage(HttpMethod.Get, "/weatherforecast");
        // When
        var response = await Client.SendAsync(request);
        // Then
        response.EnsureSuccessStatusCode();
    }
}
