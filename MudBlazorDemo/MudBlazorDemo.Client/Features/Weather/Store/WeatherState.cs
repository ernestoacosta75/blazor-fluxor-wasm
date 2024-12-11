using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.Weather.Store
{
    public record WeatherState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public WeatherForecast[] Forecasts { get; init; }
    }
}
