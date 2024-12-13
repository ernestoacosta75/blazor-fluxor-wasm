using Blazored.Toast.Services;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazorDemo.Client.Features.Counter.Store;
using MudBlazorDemo.Client.Features.Weather.Store;

namespace MudBlazorDemo.Client.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public IState<CounterState> CounterState { get; set; }

        [Inject]
        public IState<WeatherState> WeatherState { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private string WeatherItemClass => WeatherState.Value.Loading ? "font-weight-bold" : null;

        protected override void OnInitialized()
        {
            SubscribeToAction<WeatherSetForecastsAction>(action =>
            {
                Console.WriteLine("Action triggered! Showing toast...");
                ShowWeatherToast(action);
            });
            base.OnInitialized();
        }

        private void ShowWeatherToast(WeatherSetForecastsAction action)
        {
            ToastService.ShowInfo("Weather Forecasts have been updated!");
        }
    }
}
