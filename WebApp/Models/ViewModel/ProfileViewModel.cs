using Microsoft.AspNetCore.Http;
using System;

namespace WebApp.Models.ViewModel
{
    public class ProfileViewModel
    {
        
        public string FullName { get; set; }
        public IFormFile File { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Username { get; set; }
        public string IfChanged { get; set; }
        
    }
}
