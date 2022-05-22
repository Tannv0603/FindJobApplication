using AutoMapper;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;
using WebApp.Services.AppliedService;
using WebApp.Services.CityService;

namespace WebApp.Services.JobService
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppliedService _appliedService;
        private readonly IMapper _mapper;
        public JobService(IJobRepository jobRepository, 
            IUnitOfWork unitOfWork,
            IEmployeeAppliedForJobRepository appliedJob,
            IAppliedService appliedService)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
            _appliedService = appliedService;
        }

        
        public async Task<Response<Job>> GetAll()
        {
            var jobs = await _jobRepository.DbSet
                .AsNoTracking()
                .Include(x=> x.Skill)
                .Include(x=>x.City)
                .Include(job =>job.JobType)
                .Include(job => job.Employer)
                .ToListAsync();
            if (jobs == null) 
            {
                return new Response<Job>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<Job>(true, dataset: jobs, DisplayConstant.SUCCESS);
        }

        public async Task<Response<Job>> GetById(int id)
        {
            var job =  await _jobRepository.DbSet
                .AsNoTracking()
                .Include(x => x.Skill)
                .Include(x => x.City)
                .Include(job => job.JobType)
                .Include(job => job.Employer)
                .FirstOrDefaultAsync(job => job.JobId==id);
            if(job == null)
            {
                return new Response<Job>(false, data: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<Job>(true, data: job, DisplayConstant.SUCCESS);
        }

        public async Task<Response<Job>> GetJobAppliedByEmployeeId(string employeeId)
        {
            var collectingApply = await _appliedService.GetAppliedByEmployee(employeeId);
            var result = new List<Job>();
            if(collectingApply.Success)
            {
                foreach( var apply in collectingApply.DataSet)
                {
                    var job = await GetById(apply.JobId);
                    result.Add(job.Data);
                }
                return new Response<Job>(true, result, DisplayConstant.SUCCESS);
            }    
            return  new Response<Job>(false, dataset:null, DisplayConstant.ERROR_LOADFAIL);
        }

        public async Task<Response<Job>> GetJobCreatedByEmployerId(string employerId)
        {
           var jobs = await _jobRepository.DbSet
                .AsNoTracking()
                .Where(job => job.EmployerId==employerId)
                .ToListAsync();
            if(jobs == null)
            {
                return new Response<Job>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<Job>(true, jobs, DisplayConstant.SUCCESS);
        }

        public async Task<Response<Job>> CreateJob(JobRequest request)
        {           
            if (request == null)
            {
                return new Response<Job>(false, data: null, DisplayConstant.ERROR_BADREQUEST);
            }    
            try
            {
                var job = MappingRequest(request);
                await _jobRepository.DbSet.AddAsync(job);
                await _unitOfWork.SaveChangesAsync();
                var result = await _jobRepository.DbSet.LastAsync();
                return new Response<Job>(true, result, DisplayConstant.SUCCESS);
            }
            catch
            {
                return new Response<Job>(false, data:null, DisplayConstant.ERROR_CREATED);
            }
        }

       public async Task<Response<Job>> DeleteJob(int id)
        {
            var job = await GetById(id);
            if(!job.Success)
            {
                return new Response<Job>(false, data: null, DisplayConstant.ERROR_INSTANCE_NOT_FOUND);
            }
            try
            {
                 _jobRepository.DbSet.Remove(job.Data);
                await _unitOfWork.SaveChangesAsync();
                return new Response<Job>(true, data:null, DisplayConstant.SUCCESS);
            }
            catch
            {
                return new Response<Job>(false, job.Data, DisplayConstant.ERROR_REMOVED);
            }
        }
        private Job MappingRequest(JobRequest request)
        {
            var job = _mapper.Map<Job>(request);
            return job;
        }
        

        

      

      
    }
}
