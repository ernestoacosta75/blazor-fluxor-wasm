using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Client.Features.UserFeedback.Store
{
    public record UserFeedbackState
    {
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }
        public string ErrorMessage { get; init; }
        public UserFeedbackModel Model { get; init; }
    }
}
