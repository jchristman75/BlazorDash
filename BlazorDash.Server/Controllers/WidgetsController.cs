using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDash.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDash.Server.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : ControllerBase
    {
        private readonly IWidgetService WidgetService;
        public WidgetsController(IWidgetService widgetService)
        {
            WidgetService = widgetService;
        }

        [HttpGet]
        public IEnumerable<WidgetSettingsBase> widgets()
        {
            return WidgetService.GetWidgets();
        }


        [HttpPost]
        public void AddOrUpdate([FromBody] WidgetSettingsBase settings)
        {
            WidgetService.AddOrUpdate(settings);
        }

        [HttpPost]
        public bool Remove([FromBody] Guid settingsGuid)
        {
            return WidgetService.Remove(settingsGuid);
        }

    }
}
