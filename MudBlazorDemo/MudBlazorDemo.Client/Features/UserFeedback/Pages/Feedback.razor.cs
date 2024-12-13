using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazorDemo.Client.Features.UserFeedback.Store;
using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.UserFeedback.Pages
{
    public partial class Feedback
    {
        [Inject]
        public IState<UserFeedbackState> UserFeedbackState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        private UserFeedbackModel model => UserFeedbackState.Value.Model;

        private void OnValidSubmit()
        {
            Dispatcher.Dispatch(new UserFeedbackSubmitAction(model));
        }
    }
}
