using Fluxor;
using MudBlazorDemo.Shared.Models;
using System.Net.Http.Json;

namespace MudBlazorDemo.Client.Features.Weather.Store
{
    public class WeatherEffects
    {
        private readonly HttpClient Http;

        public WeatherEffects(HttpClient http)
        {
            Http = http;
        }

        [EffectMethod(typeof(WeatherLoadForecastsAction))]
        public async Task LoadForecasts(IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new WeatherSetLoadingAction(true));

            var forecasts = await
                Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");

            dispatcher.Dispatch(new WeatherSetForecastsAction(forecasts));
            dispatcher.Dispatch(new WeatherSetLoadingAction(false));
        }
    }
}
