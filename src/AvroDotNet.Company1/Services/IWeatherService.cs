namespace AvroDotNet.Company1.Services;

using AvroDotNet.Company1.Models;

/// <summary>
/// Interface for weather service operations
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Gets weather forecasts
    /// </summary>
    /// <param name="days">Number of days to forecast</param>
    /// <returns>Collection of weather forecasts</returns>
    Task<IEnumerable<WeatherForecast>> GetForecastAsync(int days = 5);
}
