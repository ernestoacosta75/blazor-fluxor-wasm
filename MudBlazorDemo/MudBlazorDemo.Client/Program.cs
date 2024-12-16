using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Text.Json;
using MudBlazorDemo.Client.Features.Counter.Store;
using MudBlazorDemo.Client.Features.Weather.Store;
using Blazored.Toast;
using MudBlazorDemo.Client.Features.UserFeedback.Store;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"]) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<WeatherEffects>();
builder.Services.AddScoped<UserFeedbackEffects>();

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(CounterState).Assembly, typeof(WeatherState).Assembly, typeof(UserFeedbackState).Assembly);
#if DEBUG
    options.UseReduxDevTools(rdt =>
    {
        rdt.Name = "MudBlazorDemo";
        rdt.JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    });
#endif
});

await builder.Build().RunAsync();
