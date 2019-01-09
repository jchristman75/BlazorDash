using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using myDash.Shared;
using Newtonsoft.Json;

namespace myDash.Server
{
    public class WidgetService : IWidgetService
    {
        private JsonSerializerSettings jsonSettings;
        public WidgetService()
        {
            jsonSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
            Refresh();
        }

        private List<WidgetSettingsBase> widgets;

        public IEnumerable<WidgetSettingsBase> GetWidgets()
        {
            return widgets;
        }

        private const string storage = @"widgets.json";
        public void Refresh()
        {
            if (File.Exists(storage))
            {
                var data = File.ReadAllText(storage);
                var items = JsonConvert.DeserializeObject<WidgetSettingsBase[]>(data, jsonSettings);
                widgets = new List<WidgetSettingsBase>(items);
            }

            if (!(widgets?.Any() ?? false))
            {
                widgets = new List<WidgetSettingsBase>(LoadDefaults());
                Save();
            }
        }

        public WidgetSettingsBase Save(WidgetSettingsBase settings = null)
        {
            //Save to datastore.
            var items = JsonConvert.SerializeObject(widgets.ToArray(), jsonSettings);
            File.WriteAllText(storage, items);

            return settings;
        }

        private WidgetSettingsBase[] LoadDefaults()
        {
            return new WidgetSettingsBase[]
            {
                new LifeCountdownSetting()
                {
                    Guid = new Guid("6CF305CD-1825-4C6A-97E2-2E43B2C72D37"),
                    Header = "Jim", BirthDate = new DateTime(1970, 1, 1), EndAge = 70
                },
                new LifeCountdownSetting()
                {
                    Guid = new Guid("C250B159-8F5E-4766-80BF-8216DCA241BB"),
                    Header = "Bob", BirthDate = new DateTime(1990, 7, 4), EndAge = 75
                },
                new LifeCountdownSetting()
                {
                    Guid = new Guid("A234E091-0C46-4635-A73E-08A0A3ABD381"),
                    Header = "Rick", BirthDate = new DateTime(1985, 4, 27), EndAge = 80
                },
                new SimpleCardSetting()
                {
                    Guid = new Guid("F03B6D0E-ADB3-4C71-80D8-D59AEC130641"),
                    Header = "This is a simple card",
                    SubHeader = "",
                    Body = "This is the body of my simple card.  There are other simple cards, but this is mine.",
                    colsLarge = 6, colsSmall = 12
                },
                new CountdownSetting()
                {
                    Guid = new Guid("4A67C3CD-F1A8-4496-8974-8025E453FFA3"),
                    Header = "Countdown to New Year",
                    StartTime = new DateTime(DateTime.Today.Year, 1, 1),
                    EndTime = new DateTime(DateTime.Today.Year + 1, 1, 1)
                },
                new CountdownSetting()
                {
                    Guid = new Guid("082DC28D-E203-4C8D-8B3E-4EDE1235E370"),
                    Header = "Countdown to July 4th",
                    StartTime = new DateTime(DateTime.Today.Year, 7, 4),
                    EndTime = new DateTime(DateTime.Today.Year + 1, 7, 4)
                },
                new WidgetSettings() {Guid = new Guid("DB9FD4FA-D5E8-4FB8-9AA9-9B0B6C584CFD"), widget = "CanvasWidget"}
            };
        }

    }
}
