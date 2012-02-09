using System;
using System.Xml;
using System.Xml.Serialization;
using WeatherDotGov.Models;
using JetBrains.Annotations;
using Orchard.Caching;
using Orchard.Services;
using WeatherDotGov.Types;

namespace WeatherDotGov.Services
{
    [UsedImplicitly]
    public class WeatherDotGovService : IWeatherDotGovService
    {
        protected ICacheManager CacheManager { get; private set; }
        protected IClock Clock { get; private set; }

        public WeatherDotGovService(ICacheManager cacheManager, IClock clock)
        {
            CacheManager = cacheManager;
            Clock = clock;
        }

        protected CurrentWeather RetrieveCurrentConditions(CurrentWeatherPart part)
        {
            // Initialize objects
            var currentConditions = new CurrentWeather();

            // New Source
            var callingUrl = String.Format(part.Url, part.Location);
            var xmlSerializer = new XmlSerializer(typeof(current_observation));
            var wcResults = (current_observation)xmlSerializer.Deserialize(XmlReader.Create(callingUrl));

            currentConditions.CurrentConditions = wcResults;
            currentConditions.ApiStatus = String.Format(part.Url, part.Location);
            currentConditions.TimeCached = DateTime.UtcNow;

            return currentConditions;
        }

        public CurrentWeather GetCurrentWeatherConditions(CurrentWeatherPart part)
        {
            var cacheKey = "WeatherDotGov_CurrentConditions_For_" + part.Location;

            return CacheManager.Get(cacheKey, ctx =>
            {
                ctx.Monitor(Clock.When(TimeSpan.FromMinutes(part.MinutesToCache)));
                return RetrieveCurrentConditions(part);
            });
        }
    }
}