using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class NewJob
    {
        public string JobName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal StartSalary { get; set; }
        public decimal EndSalary { get; set; }
        public string? Tags { get; set; }
        public string JobType { get; set; }
        public string Skill { get; set; }
        public string SkillLevel { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
