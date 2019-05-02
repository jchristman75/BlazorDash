namespace BlazorDash.Shared
{
    public class SimpleCardSetting : WidgetSettingsBase
    {
        public override string widget => "SimpleCard";
        public string Header { get; set; } = "Simple Card";
        public string SubHeader { get; set; } = "Sub Header";
        public string Body { get; set; } = "Body";

    }
}