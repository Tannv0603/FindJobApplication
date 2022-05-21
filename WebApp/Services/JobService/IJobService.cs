using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.ViewModel;

namespace WebApp.Services.JobService
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();
        Task<Job> GetById(int id);
        Task<IEnumerable<Job>> GetJobAppliedByEmployeeId(string employeeId);
        Task<IEnumerable<Job>> GetJobCreateddByEmployerId(string employerId);
        Task<bool> CreateJob(JobCreateRequest request);
        Task<bool> DeleteJob(int id);
    }
}