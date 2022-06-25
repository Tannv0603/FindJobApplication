using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.ViewModel;
using WebApp.Services.CityService;
using WebApp.Services.JobService;
using WebApp.Services.JobTitleService;
using WebApp.Services.SkillService;

namespace WebApp.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IJobService _jobService;
        private readonly ICityService _cityService;
        private readonly ISkillService _skillService;
        private readonly IJobTitleService _jobTitleService;
        private readonly UserManager<User> _userManager;        
        public EmployerController(IJobService jobService
            , ICityService cityService
            , IJobTitleService jobTitleService
            , ISkillService skillService
            , UserManager<User> userManager)
        {
            _jobTitleService = jobTitleService;
            _jobService = jobService;
            _cityService = cityService;
            _skillService = skillService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> AddJob()
        {
            var cities = await _cityService.GetAll();
            var titles = await _jobTitleService.GetAll();
            var skills = await _skillService.GetAll();
            var ViewModel = new AddJobViewModel()
            {
                Cities = cities.DataSet,
                Titles = titles.DataSet,
                Skills = skills.DataSet
            };
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddJob(NewJob newJob, IFormFile file)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var result = await _jobService.CreateJob(newJob,file,userid);
            if (result.Success)
            {
                ViewBag.Message = "Successfull";
                return RedirectToAction("JobManagement");
            }
            else
            {
                ViewBag.Message = DisplayConstant.ERROR_CREATED;
                return RedirectToAction("AddJob");
            }
        }
        public async Task<IActionResult> JobManagement()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var jobs = await _jobService.GetJobCreatedByEmployerId(userid);
            return View(jobs.DataSet);
        }
    }
}
