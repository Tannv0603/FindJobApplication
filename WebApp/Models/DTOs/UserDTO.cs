using System.Collections.Generic;

namespace WebApp.Models.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
