using System.Data;
using WeatherDotGov.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace WeatherDotGov {
    public class Migrations : DataMigrationImpl {

        public int Create()
        {
            // Creating table WeatherPartRecord
            SchemaBuilder.CreateTable("CurrentWeatherPartRecord", table => table
                                                                    .ContentPartRecord()
                                                                    .Column("url", DbType.String)
                                                                    .Column("location", DbType.String)
                                                                    .Column("minutesToCache", DbType.Int32)
                );

            ContentDefinitionManager.AlterPartDefinition(typeof(CurrentWeatherPart).Name, cfg => cfg.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("CurrentWeatherPartRecord", cfg => cfg
                .WithPart("CurrentWeatherPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            return 1;
        }
    }
}