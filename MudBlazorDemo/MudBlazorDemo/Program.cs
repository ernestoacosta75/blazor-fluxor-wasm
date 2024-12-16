using System.Text.Json;
using Blazored.Toast;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using MudBlazor.Services;
using MudBlazorDemo.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"]) });
builder.Services.AddBlazoredToast();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(
        typeof(MudBlazorDemo.Client.Features.Counter.Store.CounterFeature).Assembly,
        typeof(MudBlazorDemo.Client.Features.Weather.Store.WeatherFeature).Assembly,
        typeof(MudBlazorDemo.Client.Features.UserFeedback.Store.UserFeedbackFeature).Assembly);

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MudBlazorDemo.Client._Imports).Assembly);

app.Run();
