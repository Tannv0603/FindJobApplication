using System.ComponentModel.DataAnnotations;
using WebApp.Constant;

namespace WebApp.Models.RequestModel
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = DisplayConstant.ERROR_PASSWORD_REQUIRED)]
        public string UserName { get; set; }
        [Required(ErrorMessage = DisplayConstant.ERROR_PASSWORD_REQUIRED)]
        [MinLength(6, ErrorMessage = DisplayConstant.ERROR_PASSWORD_VALIDATE)]
        public string Password { get; set; }
    }
}
