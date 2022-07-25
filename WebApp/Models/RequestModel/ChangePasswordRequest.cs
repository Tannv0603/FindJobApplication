using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.RequestModel
{
    public class ChangePasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
