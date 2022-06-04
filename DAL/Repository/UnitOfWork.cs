using DAL.Entities;
using DAL.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FindingJobContext _context;
        public UnitOfWork(FindingJobContext context)
        {
            _context = context;
        }

        public void ClearTracked()
        {
            _context.ChangeTracker.Clear();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
