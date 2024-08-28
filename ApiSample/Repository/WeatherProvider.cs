using ApiSample.Models;

namespace ApiSample.Repository;

public class WeatherProvider
{
    private readonly TestDbContext _context;

    public WeatherProvider(TestDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveWeatherToDatabase(WeatherForecast weatherForecast)
    {
        try
        {
            _context.WeatherForecasts.Add(weatherForecast);
            var output = await _context.SaveChangesAsync();
            return output;
        }
        catch (Exception)
        {
            throw;
        }
    }
}