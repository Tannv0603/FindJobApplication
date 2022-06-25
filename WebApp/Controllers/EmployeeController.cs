using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Services.CityService;
using WebApp.Services.JobService;
using WebApp.Services.JobTitleService;
using WebApp.Services.SkillService;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IJobService _jobService;
        private readonly ICityService _cityService;
        private readonly ISkillService _skillService;
        private readonly IJobTitleService _jobTitleService;
        public EmployeeController(IJobService jobService
            , ICityService cityService
            , IJobTitleService jobTitleService
            , ISkillService skillService)
        {
            _jobTitleService = jobTitleService;
            _jobService = jobService;
            _cityService = cityService;
            _skillService = skillService;
        }
        
        public IActionResult ListCv()
        {
            return View();
        }
        public IActionResult AppliedJob()
        {
            return View();
        }
        public IActionResult UpdateProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProfile(EmpProfileRequest empRequest)
        {
            return View();
        }
    }
}
