using Microsoft.AspNetCore.Mvc;
using MudBlazorDemo.Shared.Models;

namespace MudBlazorDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        [HttpPost]
        public void Post(UserFeedbackModel userFeedbackModel)
        {
            var email = userFeedbackModel.EmailAddress;
            var rating = userFeedbackModel.Rating;
            var comment = userFeedbackModel.Comment;

            Console.WriteLine($"Received rating {rating} from {email} with comment {comment}");
        }
    }
}
