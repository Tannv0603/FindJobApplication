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
        private readonly IEmployeeAppliedForJobRepository _appliedRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppliedService(IEmployeeAppliedForJobRepository repository, IUnitOfWork unitOfWork)
        {
            _appliedRepository = repository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Response<EmployeeAppliedForJob>> ApplyForJob(int cvId, int jobId)
        {
            var IsApplied = await _appliedRepository.DbSet
                .FirstOrDefaultAsync(app => app.JobId == jobId && app.Cvid == cvId);
            if (IsApplied != null)
                return new Response<EmployeeAppliedForJob>(false,IsApplied,DisplayConstant.ERROR_INSTANCE_EXISTED);
            try
            {
                var Applying = new EmployeeAppliedForJob()
                {
                    Cvid = cvId,
                    JobId = jobId,
                    Date = DateTime.Now
                };
               var result = _appliedRepository.DbSet.Add(Applying);
               await _unitOfWork.SaveChangesAsync();
                return new Response<EmployeeAppliedForJob>(true, Applying, DisplayConstant.SUCCESS_CREATED);
            }
            catch
            {
                return new Response<EmployeeAppliedForJob>(false,data:null, DisplayConstant.ERROR_CREATED);

            }

        }

        public async Task<Response<EmployeeAppliedForJob>> GetAppliedByEmployee(string id)
        {
            var applied = await _appliedRepository.DbSet
                 .Include(item => item.Cv).ThenInclude(cv => cv.Employee).ThenInclude(emp => emp.EmployeeNavigation)
                 .Include(item => item.Job).ThenInclude(job => job.Employer).ThenInclude(emp => emp.EmployerNavigation)
                 .Include(item => item.Job).ThenInclude(job => job.City)
                 .Include(item => item.Job).ThenInclude(job => job.Skill)
                 .Include(item => item.Job).ThenInclude(job => job.JobTitle)
                 .OrderByDescending(item => item.Date)
                 .Where(item => item.Cv.EmployeeId == id).ToListAsync();
            if(applied == null)
            {
                return new Response<EmployeeAppliedForJob>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<EmployeeAppliedForJob>(true, dataset: applied, DisplayConstant.SUCCESS);
        }

        public async Task<Response<EmployeeAppliedForJob>> GetAppliedByJob(int jobid)
        {
            var cvs = await _appliedRepository.DbSet
                 .Include(item => item.Cv).ThenInclude(cv => cv.Employee).ThenInclude(emp => emp.EmployeeNavigation)
                 .Include(item => item.Job).ThenInclude(job => job.Employer).ThenInclude(emp => emp.EmployerNavigation)
                 .Include(item => item.Job).ThenInclude(job => job.City)
                 .Include(item => item.Job).ThenInclude(job => job.Skill)
                 .Include(item => item.Job).ThenInclude(job => job.JobTitle)
                .Where(applied => applied.JobId == jobid).OrderByDescending(item => item.Date)
                .ToListAsync();

            return new Response<EmployeeAppliedForJob>()
            {
                DataSet = cvs,
                Message = DisplayConstant.SUCCESS,
                Success = true
            };

        }

        public async Task<Response<EmployeeAppliedForJob>> UnapplyForJob(int jobId, string employeeId)
        {
            var IsApplied = await _appliedRepository.DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(app => app.JobId == jobId && app.Cv.EmployeeId == employeeId);
            if (IsApplied != null)
                return new Response<EmployeeAppliedForJob>(false, IsApplied, DisplayConstant.ERROR_INSTANCE_NOT_FOUND);
            try
            {
                _appliedRepository.DbSet.Remove(IsApplied);
                await _unitOfWork.SaveChangesAsync();
                return new Response<EmployeeAppliedForJob>(true, data:null, DisplayConstant.SUCCESS_REMOVED);
            }
            catch
            {
                return new Response<EmployeeAppliedForJob>(false, IsApplied, DisplayConstant.ERROR_REMOVED);
            }
        }
    }
}
