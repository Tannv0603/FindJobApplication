using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class ContactEmployee
    {
        public string EmployeeId { get; set; }
        public int JobTitleId { get; set; }
        public int JobSkill { get; set; }
        public int SkillLevel { get; set; }
        public int Cvid { get; set; }

        public virtual Cv Cv { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Skill JobSkillNavigation { get; set; }
        public virtual JobTitle JobTitle { get; set; }
    }
}
