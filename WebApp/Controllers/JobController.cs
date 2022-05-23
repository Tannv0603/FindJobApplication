using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services.JobService;

namespace WebApp.Controllers
{
    public class JobController:Controller 
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAll();
            if (jobs.Success) return View(jobs.DataSet);
            return View("Error", new ErrorViewModel() { RequestId = jobs.Message });
        }
        public async Task<IActionResult> Detail(int id)
        {
            var job = await _jobService.GetById(id);
            if(job.Success) return View(job.Data);
            return View("Error", new ErrorViewModel() { RequestId=job.Message});
        }
    }
}
