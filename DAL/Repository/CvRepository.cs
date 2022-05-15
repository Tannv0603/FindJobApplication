using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CvRepository : GenericRepository<Cv>, ICvRepository
    {
        public CvRepository(FindingJobContext context) : base(context)
        {
        }
    }
}
