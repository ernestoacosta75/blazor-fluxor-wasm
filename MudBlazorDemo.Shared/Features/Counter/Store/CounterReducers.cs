using Fluxor;

namespace MudBlazorDemo.Client.Features.Counter.Store
{
    public class CounterReducers
    {
        /**
         * There are two ways to declare a ReducerMethod:
         * - If the action contains a payload, provide both state and action as parameters, 
         *   leaving ReducerMethod annotation as [ReducerMethod].
         *   
         * - Otherwise, use the ReducerMethod annotation as below.
         */
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
