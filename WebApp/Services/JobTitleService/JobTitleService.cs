using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.Response;

namespace WebApp.Services.JobTitleService
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JobTitleService(IJobTitleRepository jobTitleRepository
            ,IUnitOfWork unitOfWork
            )
        {
            _jobTitleRepository = jobTitleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<JobTitle>> GetAll()
        {
            var jobsTitle = await _jobTitleRepository.DbSet
                 .AsNoTracking()
                 .Include(j => j.Jobs)
                 .ToListAsync();
            if(jobsTitle == null)
            {
                return new Response<JobTitle>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<JobTitle>(true, dataset: jobsTitle, DisplayConstant.SUCCESS);
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
