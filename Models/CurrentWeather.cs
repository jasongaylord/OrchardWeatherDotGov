using System;
using WeatherDotGov.Types;

namespace WeatherDotGov.Models
{
    public class CurrentWeather
    {
        public current_observation CurrentConditions { get; set; }
        public DateTime TimeCached { get; set; }
        public String ApiStatus { get; set; }
    }
}