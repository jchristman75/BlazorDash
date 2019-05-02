using System;

namespace BlazorDash.Shared
{
    public class CountdownSetting : WidgetSettingsBase
    {
        public override string widget => "Countdown";
        public override int colsLarge { get; set; } = 6;
        public override int colsSmall { get; set; } = 12;
        public string Header { get; set; } = "Countdown";

        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(16);
        public DateTime? StartTime { get; set; } = DateTime.Now.AddDays(-5);
    }
}