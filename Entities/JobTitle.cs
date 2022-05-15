using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            Jobs = new HashSet<Job>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
