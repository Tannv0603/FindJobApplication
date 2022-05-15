using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository.Abstractions;
namespace DAL.Repository
{
    public class ReviewRepository:GenericRepository<Review>,IReviewRepository
    {
        public ReviewRepository(FindingJobContext context) : base(context)
        {

        }
    }
}
