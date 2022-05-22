using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.JobTitleService
{
    public interface IJobTitleService
    {
        Task<Response<JobTitle>> GetAll();
        Task<Response<JobTitle>> GetById(int id);
        Task<Response<JobTitle>> GetByName(string name);
    }
}
