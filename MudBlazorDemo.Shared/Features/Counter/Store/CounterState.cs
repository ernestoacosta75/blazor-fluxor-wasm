using Fluxor;

namespace MudBlazorDemo.Client.Features.Counter.Store
{
    [FeatureState]
    public record CounterState
    {
        public int CurrentCount { get; init; }
    }
}
