using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazorDemo.Client.Features.Weather.Store;

namespace MudBlazorDemo.Client.Features.Weather.Pages
{
    public partial class Weather
    {
        [Inject]
        public IDispatcher Dispatcher { get; set; }

        [Inject]
        public IState<WeatherState> WeatherState { get; set; }

        private Shared.Models.WeatherForecast[] _forecasts => WeatherState.Value.Forecasts;
        private bool _loading => WeatherState.Value.Loading;

        protected override void OnInitialized()
        {
            if (WeatherState.Value.Initialized == false)
            {
                LoadForecasts();
                Dispatcher.Dispatch(new WeatherSetInitializedAction());
            }

            base.OnInitialized();
        }

        private void LoadForecasts()
        {
            Dispatcher.Dispatch(new WeatherLoadForecastsAction());
        }
    }
}
