﻿using myDash.Shared;
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
                new LifeCountdownSetting(){Header = "Jim", BirthDate = new DateTime(1970,1,1), EndAge = 70},
                new LifeCountdownSetting(){Header = "Bob", BirthDate = new DateTime(1990,7,4), EndAge = 75},
                new LifeCountdownSetting(){Header = "Rick", BirthDate = new DateTime(1985,4,27), EndAge = 80},
                new WidgetSettings() {widget = "SimpleCard", parameters = {{"Header", "This is a simple card"}, {"SubHeader", ""},
                    { "Body","This is the body of my simple card.  There are other simple cards, but this is mine."},
                    { "colsLarge", 6}, {"colsSmall", 12}}},
                new WidgetSettings() {widget = "Countdown", parameters =
                {
                    {"Header","Countdown to New Year" },
                    {"From",$"{DateTime.Today.Year}/1/1"},
                    {"To", $"{DateTime.Today.Year+1}/1/1"}
                }},
                new WidgetSettings() {widget = "Countdown", parameters =
                {
                    {"Header","Countdown to July 4th" },
                    {"From",$"{DateTime.Today.Year}/7/4"},
                    {"To", $"{DateTime.Today.Year+1}/7/4"}
                }},
                new WidgetSettings() {widget = "CanvasWidget"}
            };
            return widgets;
        }
    }
}
