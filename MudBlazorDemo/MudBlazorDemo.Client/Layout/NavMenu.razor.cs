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

        private string WeatherItemClass => WeatherState.Value.Loading ? "font-weight-bold" : null;
    }
}
