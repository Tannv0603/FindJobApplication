using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Employer
    {
        public Employer()
        {
            Jobs = new HashSet<Job>();
        }

        public string EmployerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }

        public virtual User EmployerNavigation { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
