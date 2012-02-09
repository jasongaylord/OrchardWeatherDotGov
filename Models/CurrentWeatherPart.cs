using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;

namespace WeatherDotGov.Models
{
    public class CurrentWeatherPart : ContentPart<CurrentWeatherPartRecord>
    {
        [Required]
        [DefaultValue("http://www.weather.gov/xml/current_obs/{0}.xml")] 
        public string Url
        {
            get { return Record.url; }
            set { Record.url = value; }
        }

        [Required]
        [DefaultValue("KNYC")]
        public string Location
        {
            get { return Record.location; }
            set { Record.location = value; }
        }

        [Required]
        [DefaultValue(60)]
        public int MinutesToCache
        {
            get { return Record.minutesToCache; }
            set { Record.minutesToCache = value; }
        }
    }
}