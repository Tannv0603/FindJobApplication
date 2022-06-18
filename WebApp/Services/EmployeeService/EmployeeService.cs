using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Response<Employee>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Employee>> GetByAppliedJob(int jobId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Employee>> GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
