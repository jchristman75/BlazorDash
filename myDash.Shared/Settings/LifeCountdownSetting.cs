using System;

namespace myDash.Shared
{
    public class LifeCountdownSetting : WidgetSettingsBase
    {
        public override string widget => "LifeCountdown";
        public string Header { get; set; } = "Name";
        public DateTime BirthDate { get; set; } = new DateTime(1970,1,1);
        public int EndAge { get; set; } = 75;
    }
}