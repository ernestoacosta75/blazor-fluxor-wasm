using Fluxor;
using MudBlazorDemo.Shared.Models;
using System.Net.Http.Json;
using MudBlazorDemo.Client.Features.Counter.Store;

namespace MudBlazorDemo.Client.Features.Weather.Store
{
    public class WeatherEffects
    {
        private readonly IState<CounterState> CounterState;
        private readonly IState<WeatherState> WeatherState;
        private readonly HttpClient Http;

        public WeatherEffects(HttpClient http, IState<CounterState> counterState, IState<WeatherState> weatherState)
        {
            Http = http;
            CounterState = counterState;
            WeatherState = weatherState;
        }

        [EffectMethod(typeof(WeatherLoadForecastsAction))]
        public async Task LoadForecasts(IDispatcher dispatcher)
        {
            if (WeatherState.Value == null)
            {
                Console.WriteLine("WeatherState is null");
                return;
            }

            dispatcher.Dispatch(new WeatherSetLoadingAction(true));

            var forecasts = await
                Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");

            if (forecasts == null)
            {
                forecasts = Array.Empty<WeatherForecast>();
            }

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
