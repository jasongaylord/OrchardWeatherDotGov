using Orchard.ContentManagement.Records;

namespace WeatherDotGov.Models
{
    public class CurrentWeatherPartRecord : ContentPartRecord
    {
        public virtual string url { get; set; }
        public virtual string location { get; set; }
        public virtual int minutesToCache { get; set; }
    }
}