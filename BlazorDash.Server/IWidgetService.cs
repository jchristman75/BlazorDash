using System.Collections.Generic;
using BlazorDash.Shared;

namespace BlazorDash.Server
{
    public interface IWidgetService
    {
        IEnumerable<WidgetSettingsBase> GetWidgets();
        void Save();
        void ReloadDefaults();
    }
}