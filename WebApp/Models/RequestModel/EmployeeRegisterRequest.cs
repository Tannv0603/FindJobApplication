using System;

namespace WebApp.Models.RequestModel
{
    public class EmployeeRegisterRequest: UserRegisterRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
