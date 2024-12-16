namespace MudBlazorDemo.Client.Features.Counter.Store
{
    public class CounterIncrementAction
    {
    }

    public class CounterPersistStateAction
    {
        public CounterState CounterState { get; }
        public CounterPersistStateAction(CounterState counterState)
        {
            CounterState = counterState;
        }
    }

    public class CounterPersistStateSuccessAction
    {

    }

    public class CounterPersistStateFailureAction
    {
        public string ErrorMessage { get; }

        public CounterPersistStateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class CounterLoadStateAction
    {

    }

    public class CounterLoadStateSuccessAction
    {

    }

    public class CounterLoadStateFailureAction
    {
        public string ErrorMessage { get; }

        public CounterLoadStateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class CounterSetStateAction
    {
        public CounterState CounterState { get; }

        public CounterSetStateAction(CounterState counterState)
        {
            CounterState = counterState;
        }
    }

    public class CounterClearStateAction
    {

    }

    public class CounterClearStateSuccessAction
    {

    }

    public class CounterClearStateFailureAction
    {
        public string ErrorMessage { get; }

        public CounterClearStateFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
