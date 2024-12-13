using Fluxor;
using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.UserFeedback.Store
{
    public class UserFeedbackFeature : Feature<UserFeedbackState>
    {
        public override string GetName() => "UserFeedback";

        protected override UserFeedbackState GetInitialState()
        {
            var initialState = new UserFeedbackState
            {
                Submitting = false,
                Submitted = false,
                ErrorMessage = string.Empty,
                Model = new UserFeedbackModel()
            };

            return initialState;
        }
    }
}
