﻿using System.Collections.Generic;
using myDash.Shared;

namespace myDash.Server
{
    public interface IWidgetService
    {
        IEnumerable<WidgetSettingsBase> GetWidgets();
        WidgetSettingsBase Save(WidgetSettingsBase settings);
    }
}