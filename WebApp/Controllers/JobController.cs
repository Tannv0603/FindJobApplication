using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models;
using WebApp.Models.ViewModel;
using WebApp.Services.CityService;
using WebApp.Services.JobService;
using WebApp.Services.JobTitleService;

namespace WebApp.Controllers
{
    public class JobController:Controller 
    {
        private readonly IJobService _jobService;
        private readonly ICityService _cityService;
        private readonly IJobTitleService _jobTitleService;
        public JobController(IJobService jobService
            ,ICityService cityService
            ,IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
            _jobService = jobService;
            _cityService = cityService;
        }
        
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAll();
            var cities = await _cityService.GetAll();
            var titles = await _jobTitleService.GetAll();
            if (jobs.Success)
                return View(new JobViewModel { Jobs = jobs.DataSet, Cities = cities.DataSet, Titles = titles.DataSet});        
            return View("Error", new ErrorViewModel() { RequestId = jobs.Message });
        }
        public async Task<IActionResult> Detail(int id)
        {
            var job = await _jobService.GetById(id);
            if(job.Success) return View(job.Data);
            return View("Error", new ErrorViewModel() { RequestId=job.Message});
        }

        public async Task<IActionResult> Filter(FilterViewModel filter)
        {
            var jobs = await _jobService.GetAll();
            var cities = await _cityService.GetAll();
            var titles = await _jobTitleService.GetAll();
            filter.SearchFilter =""+filter.SearchFilter.Trim().ToLower();
            jobs.DataSet
                .Where(j =>
                    (j.StartSalary >= filter.StartSalary
                    && j.EndSalary <= filter.EndSalary)
                    && (j.JobName.ToLower().Contains(filter.SearchFilter)
                    || j.City.CityName.ToLower().Contains(filter.SearchFilter)
                    || j.JobTitle.TitleName.ToLower().Contains(filter.SearchFilter)
                    || j.Address.ToLower().Contains(filter.SearchFilter)
                    || j.City.CityName.ToLower().Contains(filter.City))
                    && (j.City.CityName == filter.City
                    || filter.City == null)
                    && (j.JobTitle.TitleName == filter.JobTitle
                     || filter.JobTitle == null)
                     && ((j.JobType == JobType.FullTime
                     && filter.IsFullTime)
                     || (j.JobType == JobType.Freelancer
                     && filter.IsFreeLance)
                     || (j.JobType == JobType.PartTime
                     && filter.IsPartTime)
                     || (j.JobType == JobType.Internship
                     && filter.IsInternship)
                    ))
                .ToList();
            switch(filter.SortBy)
            {
                case SortBy.Salary: jobs.DataSet.OrderByDescending(j => j.StartSalary); break;
                case SortBy.Date: jobs.DataSet.OrderByDescending(j => j.StartDate); break;
                default: jobs.DataSet.OrderByDescending(j => j.StartDate); break;
            }
            return View("Index",new JobViewModel { Jobs = jobs.DataSet, Cities = cities.DataSet, Titles = titles.DataSet });
        }
    }
}
