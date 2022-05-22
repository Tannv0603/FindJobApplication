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
        private readonly IEmployeeAppliedForJobRepository _repository;
        private readonly IJobService _jobService;
        private readonly IUnitOfWork _unitOfWork;

        public AppliedService(IEmployeeAppliedForJobRepository repository, IUnitOfWork unitOfWork, IJobService jobService)
        {
            _repository = repository;
            _jobService = jobService;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Response<EmployeeAppliedForJob>> ApplyForJob(int cvId, int jobId)
        {
            var IsApplied = await _repository.DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(app => app.JobId == jobId && app.Cvid == cvId);
            if (IsApplied == null)
                return new Response<EmployeeAppliedForJob>(false,IsApplied,DisplayConstant.ERROR_INSTANCE_EXISTED);
            try
            {
                var Applying = new EmployeeAppliedForJob()
                {
                    Cvid = cvId,
                    JobId = jobId,
                    Date = DateTime.Now
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

        public async Task<Response<EmployeeAppliedForJob>> GetAppliedByEmployee(string id)
        {
            var jobs =await _repository.DbSet.Where(job => job.Cv.EmployeeId == id).ToListAsync();
            if(jobs == null)
            {
                return new Response<EmployeeAppliedForJob>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<EmployeeAppliedForJob>(true, dataset: jobs, DisplayConstant.SUCCESS);
        }

        public async Task<Response<EmployeeAppliedForJob>> GetAppliedByJob(int id)
        {
            var emps = await _repository.DbSet.Where(job => job.JobId == id).ToListAsync();
            if (emps == null)
            {
                return new Response<EmployeeAppliedForJob>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<EmployeeAppliedForJob>(true, dataset: emps, DisplayConstant.SUCCESS);
        }

        public async Task<Response<EmployeeAppliedForJob>> UnapplyForJob(int jobId, string employeeId)
        {
            var IsApplied = await _repository.DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(app => app.JobId == jobId && app.Cv.EmployeeId == employeeId);
            if (IsApplied != null)
                return new Response<EmployeeAppliedForJob>(false, IsApplied, DisplayConstant.ERROR_INSTANCE_NOT_FOUND);
            try
            {
                _repository.DbSet.Remove(IsApplied);
                _unitOfWork.SaveChanges();
                return new Response<EmployeeAppliedForJob>(true, data:null, DisplayConstant.SUCCESS_REMOVED);
            }
            catch
            {
                return new Response<EmployeeAppliedForJob>(false, IsApplied, DisplayConstant.ERROR_REMOVED);
            }
        }
    }
}
