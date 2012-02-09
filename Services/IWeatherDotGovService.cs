using WeatherDotGov.Models;
using Orchard;

namespace WeatherDotGov.Services
{
    public interface IWeatherDotGovService : IDependency
    {
        CurrentWeather GetCurrentWeatherConditions(CurrentWeatherPart part);
    }
}