using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;

namespace WebApp.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Response<Employee>> GetAll();
        Task<Response<Employee>> GetById(string id);
        Task<Response<Employee>> GetByAppliedJob(int jobId);
        Task<Response<Employee>> AddEmployee(EmployeeRegisterRequest request);

    }
}
