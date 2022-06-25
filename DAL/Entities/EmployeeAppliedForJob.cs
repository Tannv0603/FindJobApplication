using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DAL.Entities
{
    public partial class EmployeeAppliedForJob
    {
        [Key]
        public int Cvid { get; set; }
        [Key]
        public int JobId { get; set; }
        public DateTime Date { get; set; }

        public virtual Cv Cv { get; set; }
        public virtual Job Job { get; set; }
    }
}
