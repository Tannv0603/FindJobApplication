using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.AppliedService
{
    public interface IAppliedService
    {
        Task<IEnumerable<EmployeeAppliedForJob>> GetAppliedByEmployee(string id);
        Task<IEnumerable<EmployeeAppliedForJob>> GetAppliedByJob(int id);
        Task<Response<EmployeeAppliedForJob>> ApplyForJob(int cvId, int jobId);
    }
}
