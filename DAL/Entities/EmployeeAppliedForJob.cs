using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class EmployeeAppliedForJob
    {
        public int Cvid { get; set; }
        public int JobId { get; set; }
        public DateTime Date { get; set; }

        public virtual Cv Cv { get; set; }
        public virtual Job Job { get; set; }
    }
}
