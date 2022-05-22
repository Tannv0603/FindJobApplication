using AutoMapper;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.ViewModel;
using WebApp.Services.CityService;

namespace WebApp.Services.JobService
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ICityService _cityService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public JobService(IJobRepository jobRepository, 
            IUnitOfWork unitOfWork,
            ICityService cityService)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
            _cityService = cityService;
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
            return await _jobRepository.DbSet.FindAsync(id);
        }

        public Task<IEnumerable<Job>> GetJobAppliedByEmployeeId(string employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Job>> GetJobCreateddByEmployerId(string employerId)
        {
            throw new System.NotImplementedException();
        }

      
    }
}
