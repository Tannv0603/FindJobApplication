using AutoMapper;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.ViewModel;
using WebApp.Services.CityService;

namespace WebApp.Services.JobService
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeAppliedForJobRepository _appliedJob;
        private readonly IMapper _mapper;
        public JobService(IJobRepository jobRepository, 
            IUnitOfWork unitOfWork,
            IEmployeeAppliedForJobRepository appliedJob)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
            _appliedJob = appliedJob;   
        }

        public async Task<bool> CreateJob(JobCreateRequest request)
        {
            return  true;
        }   

        public Task<bool> DeleteJob(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _jobRepository.DbSet
                .Include(x=> x.Skill)
                .Include(x=>x.City)
                .Include(job =>job.JobType)
                .Include(job => job.Employer)
                .ToListAsync();
        }

        public async Task<Job> GetById(int id)
        {
            return await _jobRepository.DbSet
                .Include(x => x.Skill)
                .Include(x => x.City)
                .Include(job => job.JobType)
                .Include(job => job.Employer)
                .FirstOrDefaultAsync(job => job.JobId==id);
        }

        public async Task<IEnumerable<Job>> GetJobAppliedByEmployeeId(string employeeId)
        {
           var appliedJob = await _appliedJob.DbSet
                .Where(x => x.Cv.EmployeeId == employeeId)
                .ToListAsync();
            var result = new List<Job>();
            foreach (var job in appliedJob)
            {
                result.Add(await GetById(job.JobId));
            }
            return result;
        }

        public Task<IEnumerable<Job>> GetJobCreateddByEmployerId(string employerId)
        {
            throw new System.NotImplementedException();
        }

      
    }
}
