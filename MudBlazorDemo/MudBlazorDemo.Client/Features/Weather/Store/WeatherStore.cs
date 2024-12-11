using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.Weather.Store
{
    // Actions
    public class WeatherSetInitializedAction {}

    public class WeatherLoadForecastsAction { }

    public class WeatherSetForecastsAction
    {
        public WeatherForecast[] Forecasts { get; }

        public WeatherSetForecastsAction(WeatherForecast[] forecasts)
        {
            Forecasts = forecasts;
        }
    }

    public class WeatherSetLoadingAction
    {
        public bool Loading { get; }

        public WeatherSetLoadingAction(bool loading)
        {
            Loading = loading;
        }
    }
}
