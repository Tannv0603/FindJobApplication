using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAL.Entities
{
    public partial class Cv
    {
        public int Cvid { get; set; }
        public string EmployeeId { get; set; }
        public string CvName { get; set; }
        public string StoredUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public virtual Employee Employee { get; set; }
        [NotMapped]
        public virtual IEnumerable<EmployeeAppliedForJob> AppliedDetail {get; set;}
    }
}
