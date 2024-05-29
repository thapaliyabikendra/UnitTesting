using Microsoft.Extensions.Logging;
using NSubstitute;
using Shouldly;
using UnitTesting.Api.Controllers;
namespace UnitTesting.Tests.Controllers;
public class WeatherForecastControllerTests
{
    private readonly WeatherForecastController _controller;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastControllerTests()
    {
        _logger = Substitute.For<ILogger<WeatherForecastController>>();
        _controller = new WeatherForecastController(_logger);
    }

    [Fact]
    public void Get_ShouldReturnWeatherForecasts()
    {
        // Act
        var result = _controller.Get();

        // Assert
        result.ShouldNotBeNull();
        var forecasts = result.ToArray();
        forecasts.Length.ShouldBe(5);

        foreach (var forecast in forecasts)
        {
            forecast.Date.ShouldBeGreaterThan(DateOnly.MinValue);
            forecast.TemperatureC.ShouldBeInRange(-20, 55);
            forecast.Summary.ShouldBeOneOf("Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching");
        }
    }
}