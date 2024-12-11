using Fluxor;

namespace MudBlazorDemo.Client.Features.Counter.Store
{
    public class CounterFeature : Feature<CounterState>
    {
        // Returns the name that Fluxor will use for the feature in the store
        public override string GetName() => "Counter";

        // Setting the initial state
        protected override CounterState GetInitialState()
        {
            return new CounterState
            {
                CurrentCount = 0
            };
        }
    }
}
