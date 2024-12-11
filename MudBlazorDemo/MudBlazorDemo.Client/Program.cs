using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Text.Json;
using MudBlazorDemo.Client.Features.Counter.Store;
using MudBlazorDemo.Client.Features.Weather.Store;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddScoped<WeatherEffects>();

builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(CounterState).Assembly);
    Console.WriteLine("WASM Scanned Assembly: " + typeof(Program).Assembly.FullName);
#if DEBUG
    o.UseReduxDevTools(rdt =>
    {
        rdt.Name = "MudBlazorDemoClient";
        rdt.EnableStackTrace();
        rdt.JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    });
#endif
});

await builder.Build().RunAsync();
