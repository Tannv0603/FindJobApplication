using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;

namespace WebApp.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Response<Employee>> GetById(string id);
        Task<Response<Employee>> UpdateAsync(Employee employee);
    }
}
