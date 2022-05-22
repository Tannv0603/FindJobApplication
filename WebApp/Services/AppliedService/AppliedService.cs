using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Response;
using WebApp.Constant;
using System;
using WebApp.Services.JobService;
using DAL.Repository.Abstractions;

namespace WebApp.Services.AppliedService
{
    public class AppliedService : IAppliedService
    {
        private readonly EmployeeAppliedForJobRepository _repository;
        private readonly IJobService _jobService;
        private readonly IUnitOfWork _unitOfWork;

        public AppliedService(EmployeeAppliedForJobRepository repository, UnitOfWork unitOfWork, IJobService jobService)
        {
            _repository = repository;
            _jobService = jobService;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Response<EmployeeAppliedForJob>> ApplyForJob(int cvId, int jobId)
        {
            var IsApplied = await _repository.DbSet.FirstOrDefaultAsync(app => app.JobId == jobId && app.Cvid == cvId);
            if (IsApplied == null)
                return new Response<EmployeeAppliedForJob>(false,IsApplied,DisplayConstant.ERROR_INSTANCE_EXISTED);
            try
            {
                var Applying = new EmployeeAppliedForJob()
                {
                    Cvid = cvId,
                    JobId = jobId,
                    Date = DateTime.Now,                                      
                    Job = await _jobService.GetById(jobId)
                };
               var result =  await _repository.DbSet.AddAsync(Applying);
                _unitOfWork.SaveChanges();
                return new Response<EmployeeAppliedForJob>(true, Applying, DisplayConstant.SUCCESS_CREATED);
            }
            catch
            {
                return new Response<EmployeeAppliedForJob>(false,data:null, DisplayConstant.ERROR_CREATED);

            }

        }

        public async Task<IEnumerable<EmployeeAppliedForJob>> GetAppliedByEmployee(string id)
        {
            return await _repository.DbSet.Where(job => job.Cv.EmployeeId == id).ToListAsync();
           
        }

        public async Task<IEnumerable<EmployeeAppliedForJob>> GetAppliedByJob(int id)
        {
            return await _repository.DbSet.Where(job => job.JobId == id).ToListAsync();
        }
    }
}
