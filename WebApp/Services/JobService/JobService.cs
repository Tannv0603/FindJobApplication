using AutoMapper;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;
using WebApp.Models.ViewModel;
using WebApp.Services.AppliedService;
using WebApp.Services.CityService;
using WebApp.Services.CloudService;
using WebApp.Services.JobTitleService;
using WebApp.Services.SkillService;

namespace WebApp.Services.JobService
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityService _cityService;
        private readonly IAppliedService _appliedService;
        private readonly IMapper _mapper;
        private readonly ISkillService _skillService;
        private readonly ICloudService _cloudService;
        private readonly IJobTitleService _jobTitleService;
        public JobService(IJobRepository jobRepository, 
            IUnitOfWork unitOfWork,
            IEmployeeAppliedForJobRepository appliedJob,
            IAppliedService appliedService,
            ICityService cityService,
            ICloudService cloudService,
            ISkillService skillService,
            IJobTitleService jobTitleService)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
            _appliedService = appliedService;
            _cityService = cityService;
            _cloudService = cloudService;   
            _skillService = skillService;
            _jobTitleService = jobTitleService;
        }

        
        public async Task<Response<Job>> GetAll()
        {
            var jobs = await _jobRepository.DbSet
                .AsNoTracking()
                .Include(x=> x.Skill)
                .Include(x=>x.City)
                .Include(x=>x.JobTitle)
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

        public async Task<Response<Job>> CreateJob(NewJob request,IFormFile file, string userid)
        {           
            if (request == null)
            {
                return new Response<Job>(false, data: null, DisplayConstant.ERROR_BADREQUEST);
            }    
            try
            {

                var jobType = new short();
                switch (request.JobType)
                {
                    case nameof(JobType.Freelancer): jobType = JobType.Freelancer; break;
                    case nameof(JobType.Internship): jobType = JobType.Internship; break;
                    case nameof(JobType.FullTime): jobType = JobType.FullTime; break;
                    case nameof(JobType.PartTime): jobType = JobType.PartTime; break;
                    default: jobType = 0; break;
                }
                var skillLevel = new short();
                switch(request.SkillLevel)
                {
                    case nameof(Level.Master): skillLevel = Level.Master; break;
                    case nameof(Level.Expert): skillLevel = Level.Expert; break;
                    case nameof(Level.Senior): skillLevel = Level.Senior; break;
                    case nameof(Level.Junior): skillLevel = Level.Junior; break;
                    case nameof(Level.Fresher): skillLevel = Level.Fresher; break;
                    default : skillLevel = 0; break;
                }
                var imagePath = _cloudService.AddImage(file);
                if (imagePath == null) imagePath =DisplayConstant.JOB_IMG_DEFAULT_PATH;
                var job = new Job()
                {
                    JobName = request.JobName.Trim(),
                    JobImage = imagePath,
                    CityId = _cityService.GetAll().Result.DataSet.FirstOrDefault(c => c.CityName == request.City).CityId,
                    SkillId = _skillService.GetAll().Result.DataSet.FirstOrDefault(s => s.SkillName == request.Skill).SkillId,
                    JobTitleId = _jobTitleService.GetAll().Result.DataSet.FirstOrDefault(jt => jt.TitleName == request.JobTitle).TitleId,
                    SkillLevel = skillLevel,
                    JobType = jobType,
                    Address = request.Address.Trim(),
                    Description = request.Description.Trim(),
                    EndDate = request.EndDate,
                    StartDate = request.StartDate,
                    StartSalary = request.StartSalary,
                    EndSalary = request.EndSalary,
                    ModifiedDate = System.DateTime.Now,
                    EmployerId = userid,
                    Tags = request.Tags,
                    Status = true
                };
                await _jobRepository.DbSet.AddAsync(job);
                await _unitOfWork.SaveChangesAsync();
                return new Response<Job>(true, data:null, DisplayConstant.SUCCESS);
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
       

        public Task<Response<Job>> UpdateJob(int id, JobRequest request)
        {
            throw new System.NotImplementedException();
        }
        private Job MappingRequest(JobRequest request)
        {
            var job = _mapper.Map<Job>(request);
            var city = _cityService.GetByName(request.City);
            job.CityId = city.Id;
            return job;
        }
    }
}
