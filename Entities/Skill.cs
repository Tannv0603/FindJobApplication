using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            Jobs = new HashSet<Job>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
