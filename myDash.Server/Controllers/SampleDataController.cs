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
        public IEnumerable<WidgetSettings> widgets()
        {
            var widgets = new[]
            {
                new WidgetSettings() {widget = "LifeCountdown", parameters =  {{"Header","Bob"},{"BirthDay", "1970/5/20"}}},
                new WidgetSettings() {widget = "LifeCountdown", parameters =  {{"Header","Jim"}, { "BirthDay", "1985/8/1"}}},
                new WidgetSettings() {widget = "LifeCountdown", parameters =  {{"Header","Rick"}, { "BirthDay", "2000/1/1"}}},
                new WidgetSettings() {widget = "LifeCountdown", parameters =  {{"Header","Bob"}, { "BirthDay", "1970/5/20"},{"EndAge", 90}}},
                new WidgetSettings() {widget = "LifeCountdown", parameters =  {{"Header","Jim"}, { "BirthDay", "1985/8/1"},{"EndAge", 90}}},
                new WidgetSettings() {widget = "LifeCountdown", parameters =  {{"Header","Rick"}, { "BirthDay", "2000/1/1"},{"EndAge", 90}}},
                new WidgetSettings() {widget = "SimpleCard", parameters = {{"Header", "This is a simple card"}, {"SubHeader", ""},
                    { "Body","This is the body of my simple card.  There are other simple cards, but this is mine."},
                    { "colsLarge", 6}, {"colsSmall", 12}}}
            };
            return widgets;
        }
    }
}
