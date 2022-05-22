using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.JobTitleService
{
    public class JobTitleService : IJobTitleService
    {
        public Task<Response<JobTitle>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<JobTitle>> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<JobTitle>> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
