namespace AvroDotNet.Company1.Controllers;

using Microsoft.AspNetCore.Mvc;
using AvroDotNet.Company1.Models;
using AvroDotNet.Company1.Services;

/// <summary>
/// Weather forecast controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public sealed class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="WeatherForecastController"/> class
    /// </summary>
    /// <param name="logger">Logger instance</param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets weather forecasts
    /// </summary>
    /// <param name="days">Number of days to forecast (default: 5)</param>
    /// <returns>Collection of weather forecasts</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery] int days = 5)
    {
        _logger.LogInformation("Getting weather forecast for {Days} days", days);

        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        var forecasts = Enumerable.Range(1, days).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        });

        return Ok(forecasts);
    }
}
