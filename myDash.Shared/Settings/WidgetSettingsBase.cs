using System;

namespace myDash.Shared
{
    public class WidgetSettingsBase
    {
        public Guid Guid { get; set; }
        public virtual string widget { get; set; }
        public virtual int colsLarge { get; set; } = 4;
        public virtual int colsSmall { get; set; } = 6;
    }
}