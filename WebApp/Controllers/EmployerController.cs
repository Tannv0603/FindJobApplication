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
using WebApp.Services.CloudService;
using WebApp.Services.EmployerService;
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
        private readonly IEmployerService _employerService;
        private readonly ICloudService _cloudService;
        public EmployerController(IJobService jobService
            , ICityService cityService
            , IJobTitleService jobTitleService
            , ISkillService skillService
            , UserManager<User> userManager
            ,ICloudService cloudService
            , IEmployerService employerService)
        {
            _jobTitleService = jobTitleService;
            _jobService = jobService;
            _cityService = cityService;
            _skillService = skillService;
            _userManager = userManager;
            _employerService = employerService;
            _cloudService = cloudService;
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
            if (userid == null)
                return RedirectToAction("Signin", "User");
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
        public async Task<IActionResult> Profile()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            if (userid == null)
                return RedirectToAction("Signin", "User");
            var emp = await _employerService.GetById(userid);
           
            var viewModel = new ProfileViewModel()
            {
                FullName = emp.Data.EmployerNavigation.FullName,
                AvatarUrl = emp.Data.EmployerNavigation.AvatarUrl,
                Email = emp.Data.EmployerNavigation.Email,
                PhoneNumber = emp.Data.EmployerNavigation.PhoneNumber,
                CompanyName = emp.Data.CompanyName

            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel request)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            if (userid == null)
                return RedirectToAction("Signin", "User");
            var user = await _userManager.FindByIdAsync(userid);

            if (request.IfChanged == "changed")
            {
                user.AvatarUrl =""+ _cloudService.AddImage(request.File);
            }
            else
            {
                user.AvatarUrl =""+ request.IfChanged;
            }
            user.FullName = request.FullName;
            user.PhoneNumber = request.PhoneNumber;
            var city = await _cityService.GetByName(request.CityName);
            var emp = new Employer()
            {
                EmployerId = userid,
               CompanyName = request.CompanyName,
            };

            var result = await _userManager.UpdateAsync(user);
            var resultEmp = await _employerService.UpdateAsync(emp);
            return RedirectToAction("Profile");
        }
    }
}
