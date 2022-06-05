using System.ComponentModel.DataAnnotations;
using WebApp.Constant;

namespace WebApp.Models.RequestModel
{
    public class UserRegisterRequest
    {
        [Required]
        public string TypeUser { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }   


        [Required(ErrorMessage = DisplayConstant.ERROR_PASSWORD_REQUIRED)]
        public string UserName { get; set; }
        [Required(ErrorMessage = DisplayConstant.ERROR_PASSWORD_REQUIRED)]
        [MinLength(6, ErrorMessage = DisplayConstant.ERROR_PASSWORD_VALIDATE)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { get; set; }
    }
}
