using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazorDemo.Client.Features.Counter.Store;

namespace MudBlazorDemo.Client.Features.Counter.Pages
{
    public partial class Counter
    {
        [Inject]
        public IDispatcher Dispatcher { get; set; }

        [Inject]
        public IState<CounterState> CounterState { get; set; }

        private void IncrementCount()
        {
            Dispatcher.Dispatch(new CounterIncrementAction());
        }
    }
}
