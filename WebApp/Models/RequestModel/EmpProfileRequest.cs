using System;

namespace WebApp.Models.RequestModel
{
    public class EmpProfileRequest:UserProfileRequest
    {
        public string Address {get;set;}
        public string City {get;set;}
        public DateTime DateOfBirth { get; set; }
    }
}
