using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.ViewModel
{
    public class JobViewModel
    {
       
        public string JobTitle { get; set; }
        public string JobName { get; set; }
        public string JobImage { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal StartSalary { get; set; }
        public decimal EndSalary { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Tags { get; set; }
        public string JobType { get; set; }
        public string SkillName { get; set; }
        public string SkillLevel { get; set; }
        public string CityName { get; set; }
        public string EmployerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public JobViewModel()
        {
               
        }
    }
}
