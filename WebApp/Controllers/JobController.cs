using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services.JobService;

namespace WebApp.Controllers
{
    public class JobController:Controller 
    {
        private readonly JobService _jobService;
        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }
        public async Task<IActionResult> GetAll()
        {
            return View( await _jobService.GetAll());
        }
        public async Task<IActionResult> GetById(int id)
        {
            return View(await _jobService.GetById(id));
        }

    }
}
