using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> DbSet { get; set; }
    }
}
