using System;

namespace BlazorDash.Shared
{
    public class WidgetSettingsBase
    {
        public Guid Guid { get; set; }
        public virtual string widget { get; set; }
        public virtual int colsLarge { get; set; } = 4;
        public virtual int colsSmall { get; set; } = 6;
        public virtual long width { get; set; } = 400;
        public virtual long height { get; set; } = 400;
    }
}