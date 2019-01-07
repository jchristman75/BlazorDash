using myDash.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myDash.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<WidgetSettingsBase> widgets()
        {
            var widgets = new WidgetSettingsBase[]
            {
                new LifeCountdownSetting(){Guid=new Guid("6CF305CD-1825-4C6A-97E2-2E43B2C72D37"),
                    Header = "Jim", BirthDate = new DateTime(1970,1,1), EndAge = 70},
                new LifeCountdownSetting(){Guid=new Guid("C250B159-8F5E-4766-80BF-8216DCA241BB"),
                    Header = "Bob", BirthDate = new DateTime(1990,7,4), EndAge = 75},
                new LifeCountdownSetting(){Guid=new Guid("A234E091-0C46-4635-A73E-08A0A3ABD381"),
                    Header = "Rick", BirthDate = new DateTime(1985,4,27), EndAge = 80},
                new SimpleCardSetting() {Guid=new Guid("F03B6D0E-ADB3-4C71-80D8-D59AEC130641"),
                    Header = "This is a simple card",
                    SubHeader = "",
                    Body ="This is the body of my simple card.  There are other simple cards, but this is mine.",
                    colsLarge= 6, colsSmall= 12},
                new CountdownSetting() {Guid=new Guid("4A67C3CD-F1A8-4496-8974-8025E453FFA3"),
                    Header = "Countdown to New Year",
                    StartTime = new DateTime(DateTime.Today.Year,1,1),
                    EndTime = new DateTime(DateTime.Today.Year+1,1,1)
                },
                new CountdownSetting() {Guid=new Guid("082DC28D-E203-4C8D-8B3E-4EDE1235E370"),
                    Header = "Countdown to July 4th",
                    StartTime = new DateTime(DateTime.Today.Year,7,4),
                    EndTime = new DateTime(DateTime.Today.Year+1,7,4)
                },
                new WidgetSettings() {Guid=new Guid("DB9FD4FA-D5E8-4FB8-9AA9-9B0B6C584CFD"),widget = "CanvasWidget"}
            };
            return widgets;
        }
    }
}
