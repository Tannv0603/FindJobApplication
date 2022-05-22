using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;
using WebApp.Models.ViewModel;

namespace WebApp.Services.JobService
{
    public interface IJobService
    {
        Task<Response<Job>> GetAll();
        Task<Response<Job>> GetById(int id);
        Task<Response<Job>> GetJobAppliedByEmployeeId(string employeeId);
        Task<Response<Job>> GetJobCreateddByEmployerId(string employerId);
        Task<Response<Job>> CreateJob(JobCreateRequest request);
        Task<Response<Job>> DeleteJob(int id);
    }
}