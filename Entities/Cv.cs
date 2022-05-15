using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Cv
    {
        public int Cvid { get; set; }
        public string EmployeeId { get; set; }
        public string StoredUrl { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
