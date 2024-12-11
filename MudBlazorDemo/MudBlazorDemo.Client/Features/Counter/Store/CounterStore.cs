using Fluxor;

namespace MudBlazorDemo.Client.Features.Counter.Store
{
    public record CounterState
    {
        public int CurrentCount { get; init; }
    }

    public class CounterIncrementAction
    {
    }

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

    public static class CounterReducers
    {
        [ReducerMethod(typeof(CounterIncrementAction))]
        public static CounterState OnIncrement(CounterState state)
        {
            return state with
            {
                CurrentCount = state.CurrentCount + 1,
            };
        }
    }
}
