using Fluxor;
using System.Net.Http.Json;

namespace MudBlazorDemo.Client.Features.UserFeedback.Store
{
    public class UserFeedbackEffects
    {
        private readonly IState<UserFeedbackState> UserFeedbackState;
        private readonly HttpClient Http;

        public UserFeedbackEffects(HttpClient http, IState<UserFeedbackState> userFeedbackState)
        {
            Http = http;
            UserFeedbackState = userFeedbackState;
        }

        [EffectMethod]
        public async Task SubmitUserFeedback(UserFeedbackSubmitAction action, IDispatcher dispatcher) 
        {
            if (UserFeedbackState.Value == null)
            {
                Console.WriteLine("UserFeedbackState is null");
                return;
            }

            try
            {
                var response = await Http.PostAsJsonAsync("Feedback/SubmitFeedback", action.UserFeedbackModel);

                if (response.IsSuccessStatusCode)
                {
                    dispatcher.Dispatch(new UserFeedbackSubmitSuccessAction());
                }
                else
                {
                    dispatcher.Dispatch(new UserFeedbackSubmitFailureAction(response.ReasonPhrase));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                dispatcher.Dispatch(new UserFeedbackSubmitFailureAction(ex.Message));
            }
        }
    }
}
