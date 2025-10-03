namespace AvroDotNet.Company1.Models;

/// <summary>
/// Weather forecast entity
/// </summary>
public sealed class WeatherForecast
{
    /// <summary>
    /// Gets or sets the date of the forecast
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the temperature in Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Gets the temperature in Fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Gets or sets the weather summary
    /// </summary>
    public string? Summary { get; set; }
}
