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

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FindingJobContext _context = new FindingJobContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            JobRepository jobRepository = new(_context);
            IEnumerable<Job> jobs = jobRepository.DbSet.ToList();
            //IEnumerable<Job> jobs = jobRepository.FindJobBySkill("PHP");
            foreach (var job in jobs)
            {
                _context.Entry(job).Reference(j => j.City).Load();
                _context.Entry(job).Reference(j => j.JobTitle).Load();
            }
            return View(jobs);
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
