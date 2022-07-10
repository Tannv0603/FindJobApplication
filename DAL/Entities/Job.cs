using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,2)")]
        public decimal StartSalary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal EndSalary { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }
        public string? Tags { get; set; }
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
        [NotMapped]
        public virtual IEnumerable<EmployeeAppliedForJob> AppliedDetail { get; set; }
        [NotMapped]
        public virtual IEnumerator<Review> Reviews { get; set; }
    }
}
