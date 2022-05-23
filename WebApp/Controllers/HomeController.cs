using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using DAL.Repository;
using DAL.Entities;
using WebApp.Services.JobService;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService _jobService;
        public HomeController (IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAll();
            return View(jobs.DataSet);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult JobDetails()
        {
            return View();
        }
        public IActionResult JobListing()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
