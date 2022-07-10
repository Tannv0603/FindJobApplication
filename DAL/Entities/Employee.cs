using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAL.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Cvs = new HashSet<Cv>();
        }

        public string EmployeeId { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        [NotMapped]
        public virtual User EmployeeNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<Cv> Cvs { get; set; }
    }
}
