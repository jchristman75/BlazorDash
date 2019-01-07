using System.Collections.Generic;

namespace myDash.Shared
{
    public class WidgetSettings : WidgetSettingsBase
    {
        public Dictionary<string, object> parameters { get; private set; } =
           new Dictionary<string, object>();
    }
}