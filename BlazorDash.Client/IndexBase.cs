using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BlazorDash.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Newtonsoft.Json;

namespace BlazorDash.Client
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

        public RenderFragment Widgets() => builder =>
        {
            if (widgets == null) return;

            var assm = Assembly.GetExecutingAssembly();
            var assmName = assm.GetName().Name;

            var seq = -1;
            foreach (var widgetSettings in widgets)
            {
                var widgetTypeName = $"{assmName}.Widgets.{widgetSettings.widget}";
                var widgetType = Type.GetType(widgetTypeName);

                if (widgetType != null)
                {
                    AddWidget(builder, widgetType, widgetSettings,ref seq);
                }
            }
        };

        private static void AddWidget(RenderTreeBuilder builder, Type widgetType, WidgetSettingsBase setting, ref int seq)
        {
            builder.OpenComponent(++seq, widgetType);
            Console.WriteLine(setting.GetType().Name);
            if (setting is WidgetSettings widgetSettings)
            {
                foreach (var param in widgetSettings.parameters)
                {
                    builder.AddAttribute(++seq, param.Key, param.Value);
                    Console.WriteLine($"{seq}, {param.Key}, {param.Value}");
                }
            }
            else
            {
                builder.AddAttribute(++seq, "Settings", setting);
                Console.WriteLine($"{seq} -- Settings");
            }
            builder.CloseComponent();
        }
    }
}
