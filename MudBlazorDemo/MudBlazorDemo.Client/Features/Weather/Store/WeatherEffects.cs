using Fluxor;
using MudBlazorDemo.Shared.Models;
using System.Net.Http.Json;
using MudBlazorDemo.Client.Features.Counter.Store;

namespace MudBlazorDemo.Client.Features.Weather.Store
{
    public class WeatherEffects
    {
        private readonly IState<CounterState> CounterState;

        private readonly HttpClient Http;

        public WeatherEffects(HttpClient http, IState<CounterState> counterState)
        {
            Http = http;
            CounterState = counterState;
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

        [EffectMethod(typeof(CounterIncrementAction))]
        public async Task LoadForecastsOnIncrement(IDispatcher dispatcher)
        {
            if (CounterState.Value.CurrentCount % 10 == 0)
            {
                dispatcher.Dispatch(new WeatherLoadForecastsAction());
            }
        }
    }
}
