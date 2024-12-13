using System.ComponentModel.DataAnnotations;

namespace MudBlazorDemo.Shared.Models
{
    public class UserFeedbackModel
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;


        [Range(1, 10)]
        [Required] 
        public int Rating { get; set; } = 1;

        [MaxLength(100)]
        public string Comment { get; set; } = string.Empty;
    }
}
