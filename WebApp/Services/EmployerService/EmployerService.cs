using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.EmployerService
{
    public class EmployerService : IEmployerService
        
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployerService(IEmployerRepository employerRepository
            , IUnitOfWork unitOfWork)
        {
            _employerRepository = employerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Employer>> GetById(string id)
        {
            var employer = await _employerRepository.DbSet.Include(e => e.EmployerNavigation).FirstOrDefaultAsync(e => e.EmployerId == id);
            return new Response<Employer>()
            {
                Data = employer,
                Success = true
            };
        }

        public async Task<Response<Employer>> UpdateAsync(Employer employer)
        {
            _employerRepository.DbSet.Update(employer);
            await _unitOfWork.SaveChangesAsync();
            return new Response<Employer>()
            {
                Success = true
            };
        }
    }
}
