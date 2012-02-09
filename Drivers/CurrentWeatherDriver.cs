using WeatherDotGov.Models;
using WeatherDotGov.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace WeatherDotGov.Drivers
{
    public class CurrentWeatherDriver : ContentPartDriver<CurrentWeatherPart>
    {
        protected IWeatherDotGovService WeatherDotGovService { get; private set; }

        public CurrentWeatherDriver(IWeatherDotGovService weatherDotGovService)
        {
            WeatherDotGovService = weatherDotGovService;
        }

        //GET
        protected override DriverResult Display(CurrentWeatherPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_CurrentWeatherWidget", () => shapeHelper.Parts_CurrentWeatherWidget(
                WeatherResults: WeatherDotGovService.GetCurrentWeatherConditions(part),
                WidgetConfiguration: part));
        }

        // GET
        protected override DriverResult Editor(CurrentWeatherPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_CurrentWeatherWidget_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/CurrentWeatherWidget",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(CurrentWeatherPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}