using Fluxor;
using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.Weather.Store
{
    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName() => "Weather";

        protected override WeatherState GetInitialState()
        {
            var initialState = new WeatherState
            {
                Initialized = false,
                Loading = false,
                Forecasts = Array.Empty<WeatherForecast>()
            };

            return initialState;
        }
    }
}
