using WeatherDotGov.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace WeatherDotGov.Handlers
{
    public class CurrentWeatherHandler : ContentHandler
    {
        public CurrentWeatherHandler(IRepository<CurrentWeatherPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}