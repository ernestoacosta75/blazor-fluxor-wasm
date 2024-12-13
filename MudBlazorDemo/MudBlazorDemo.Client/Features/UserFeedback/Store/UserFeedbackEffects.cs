using Fluxor;
using MudBlazorDemo.Client.Features.Weather.Store;
using System.Net.Http.Json;

namespace MudBlazorDemo.Client.Features.UserFeedback.Store
{
    public class UserFeedbackEffects
    {
        private readonly HttpClient Http;

        public UserFeedbackEffects(HttpClient http)
        {
            Http = http;
        }

        [EffectMethod]
        public async Task SubmitUserFeedback(IDispatcher dispatcher, UserFeedbackSubmitAction action) 
        {
            var response = await Http.PostAsJsonAsync("Feedback", action.UserFeedbackModel);

            if(response.IsSuccessStatusCode)
            {
                dispatcher.Dispatch(new UserFeedbackSubmitSuccessAction());
            }
            else
            {
                dispatcher.Dispatch(new UserFeedbackSubmitFailureAction(response.ReasonPhrase));
            }
        }
    }
}
