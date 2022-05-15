using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository.Abstractions;

namespace DAL.Repository
{
    public class EmployeeRepository:GenericRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(FindingJobContext context) : base(context)
        {
        }
    }
}
