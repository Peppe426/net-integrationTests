using ApiSample.Models;
using ApiSample.Repository;
using FluentAssertions;
using IntegrationTests.Base;
using System.Text.Json;

namespace ApiSampleNunitTests;

public class PersistentDataTests : IntegrationTest<Program, TestDbContext>
{
    [Test]
    public async Task ShouldSaveDataToDatabase()
    {
        // Given
        var request = new HttpRequestMessage(HttpMethod.Get, "/weatherforecast");
        var response = await Client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        var expectedIOutput = JsonSerializer.Deserialize<List<WeatherForecast>>(responseContent);
        expectedIOutput?.Any().Should().BeTrue();

        var provider = ResolveService<WeatherProvider>();

        // Check initial database state is empty
        DbContext.Set<WeatherForecast>().Count().Should().Be(0);

        // When
        var outcome = await provider.SaveWeatherToDatabase(expectedIOutput!.First());

        // Then
        outcome.Should().Be(1);

        // Ensure only one entity is saved to the database
        DbContext.Set<WeatherForecast>().Count().Should().Be(1);
    }


    [Test]
    public void ShouldVerifyDatabaseInitialization()
    {
        //Given        

        //When
        var tableExists = DbContext.WeatherForecasts;

        //Then        
        tableExists.Should().NotBeNull();
    }

    //[Test]
    //public async Task ShouldSaveDataToDatabase()
    //{
    //    // Given
    //    var request = new HttpRequestMessage(HttpMethod.Get, "/weatherforecast");
    //    var response = await Client.SendAsync(request);
    //    response.EnsureSuccessStatusCode();

    //    var responseContent = await response.Content.ReadAsStringAsync();
    //    var input = JsonSerializer.Deserialize<List<WeatherForecast>>(responseContent);

    //    input?.Any().Should().BeTrue();

    //    var provider = WebHost.ResolveService<WeatherProvider>();

    //    // When
    //    var outcome = provider.SaveWeatherToDatabase(input!.First());

    //    // When

    //    outcome.Should().Be(1);

    //}
}