using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.UserFeedback.Store
{
    public class UserFeedbackSubmitSuccessAction
    {
    }

    public class UserFeedbackSubmitFailureAction
    {
        public string ErrorMessage { get; }

        public UserFeedbackSubmitFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    public class UserFeedbackSubmitAction
    {
        public UserFeedbackModel UserFeedbackModel { get; }

        public UserFeedbackSubmitAction(UserFeedbackModel userFeedbackModel)
        {
            UserFeedbackModel = userFeedbackModel;
        }
    }
}
