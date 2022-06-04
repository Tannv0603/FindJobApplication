using System.ComponentModel.DataAnnotations;
using WebApp.Constant;

namespace WebApp.Models.RequestModel
{
    public class UserRegisterRequest
    {
        public string TypeUser { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }   


        [Required(ErrorMessage = DisplayConstant.ERROR_PASSWORD_REQUIRED)]
        public string UserName { get; set; }
        [Required(ErrorMessage = DisplayConstant.ERROR_PASSWORD_REQUIRED)]
        [MinLength(6, ErrorMessage = DisplayConstant.ERROR_PASSWORD_VALIDATE)]
        public string Password { get; set; }
    }
}
