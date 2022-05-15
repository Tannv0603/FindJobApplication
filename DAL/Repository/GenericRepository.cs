using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbSet<T> DbSet { get; set; }
        public GenericRepository(FindingJobContext context)
        {
            DbSet = context.Set<T>();  
        }
    }
}
