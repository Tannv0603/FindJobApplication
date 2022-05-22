using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.AppliedService
{
    public interface IAppliedService
    {
        Task<Response<EmployeeAppliedForJob>> GetAppliedByEmployee(string id);
        Task<Response<EmployeeAppliedForJob>> GetAppliedByJob(int id);
        Task<Response<EmployeeAppliedForJob>> ApplyForJob(int cvId, int jobId);
        Task<Response<EmployeeAppliedForJob>> UnapplyForJob(int jobId, string employeeId);
    }
}
