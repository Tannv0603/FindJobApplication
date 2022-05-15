using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Job
    {
        public int JobId { get; set; }
        public int JobTitleId { get; set; }
        public string JobName { get; set; }
        public string JobImage { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal StartSalary { get; set; }
        public decimal EndSalary { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public string Tags { get; set; }
        public short JobType { get; set; }
        public int SkillId { get; set; }
        public short SkillLevel { get; set; }
        public int CityId { get; set; }
        public string EmployerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual City City { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
