using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class City
    {
        public City()
        {
            Jobs = new HashSet<Job>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
