using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using myDash.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Newtonsoft.Json;

namespace myDash.Client
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }

        WidgetSettingsBase[] widgets;
        protected override async Task OnInitAsync()
        {
            Console.WriteLine("OnInitAsync");
            widgets = JsonConvert.DeserializeObject<WidgetSettingsBase[]>(await Http.GetStringAsync("api/SampleData/widgets"),
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            StateHasChanged();
        }

        public RenderFragment CreateDynamicComponent() => builder =>
        {
            if (widgets == null) return;

            var assm = Assembly.GetExecutingAssembly();
            var assmName = assm.GetName().Name;

            foreach (var widget in widgets)
            {
                var widgetType = Type.GetType($"{assmName}.Widgets.{widget.widget}");
                if (widgetType != null)
                {
                    AddWidget(builder, widgetType, widget);
                }
            }
        };

        private static void AddWidget(RenderTreeBuilder builder, Type widget, WidgetSettingsBase settings)
        {
            var seq = 0;
            builder.OpenComponent(seq, widget);

            if (settings is WidgetSettings widgetSettings)
            {
                foreach (var param in widgetSettings.parameters)
                {
                    seq++;
                    builder.AddAttribute(seq, param.Key, param.Value);
                }
            }
            else
            {
                builder.AddAttribute(seq, "Settings", settings);
            }
            builder.CloseComponent();
        }
    }
}
