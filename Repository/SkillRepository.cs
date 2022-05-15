using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SkillRepository : GenericRepository<Skill>
    {
        public SkillRepository(FindingJobContext context) : base(context)
        {

        }
    }
}