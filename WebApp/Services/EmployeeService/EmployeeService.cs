using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository
            , IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;   
        }
       

        public async Task<Response<Employee>> GetById(string id)
        {
            var employee = await _employeeRepository.DbSet.Include(e => e.EmployeeNavigation).FirstOrDefaultAsync(e => e.EmployeeId==id);
            return new Response<Employee>()
            {
                Data = employee,
                Success = true
            };
        }

        public async Task<Response<Employee>> UpdateAsync(Employee employee)
        {
           _employeeRepository.DbSet.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return new Response<Employee>()
            {
                Success = true
            };
        }
    }
}
