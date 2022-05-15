using DAL.Entities;
using DAL.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FindingJobContext context):base(context)
        {

        }
    }
}
