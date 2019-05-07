using System;
using System.Collections.Generic;
using BlazorDash.Shared;

namespace BlazorDash.Server
{
    public interface IWidgetService
    {
        IEnumerable<WidgetSettingsBase> GetWidgets();
        WidgetSettingsBase GetWidget(Guid Id);
        void AddOrUpdate(WidgetSettingsBase settings);
        bool Remove(Guid settingsGuid);
        void Save();
        void ReloadDefaults();
    }
}