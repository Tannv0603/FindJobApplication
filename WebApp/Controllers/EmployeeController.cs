using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.ViewModel;
using WebApp.Services.CityService;
using WebApp.Services.CloudService;
using WebApp.Services.EmployeeService;
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
        private readonly UserManager<User> _userManager;
        private readonly ICloudService _cloudService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IJobService jobService
            , ICityService cityService
            , IJobTitleService jobTitleService
            , ISkillService skillService
            , IEmployeeService employeeService
            , UserManager<User> userManager
            , ICloudService cloudService)
        {
            _cloudService = cloudService;
            _jobTitleService = jobTitleService;
            _jobService = jobService;
            _cityService = cityService;
            _skillService = skillService;
            _userManager = userManager;
            _employeeService = employeeService;
        }
        
       
        public async Task<IActionResult> Profile()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var emp = await _employeeService.GetById(userid);
            var city = await _cityService.GetAll();
            var cityname = await _cityService.GetById(emp.Data.CityId);
            ViewBag.Cities = city.DataSet;
            var viewModel = new ProfileViewModel()
            {
                DayOfBirth = emp.Data.DateOfBirth,
                Address = emp.Data.Address,
                FullName = emp.Data.EmployeeNavigation.FullName,
                AvatarUrl = emp.Data.EmployeeNavigation.AvatarUrl,
                Email = emp.Data.EmployeeNavigation.Email,
                PhoneNumber = emp.Data.EmployeeNavigation.PhoneNumber,
                CityName= cityname.Data.CityName 

            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile( ProfileViewModel request)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);

            var user =await _userManager.FindByIdAsync(userid);

            if (request.IfChanged == "changed")
            {
                user.AvatarUrl = _cloudService.AddImage(request.File);
            }
            else
            {
                user.AvatarUrl = request.IfChanged;
            }
            user.FullName=request.FullName;
            user.PhoneNumber=request.PhoneNumber;
            var city = await _cityService.GetByName(request.CityName);
            var emp = new Employee()
            {
                EmployeeId = userid,
                Address = ""+request.Address,
                CityId = city.Data.CityId,
                DateOfBirth = request.DayOfBirth
            };

            var result = await _userManager.UpdateAsync(user);
            var resultEmp = await _employeeService.UpdateAsync(emp);
            return RedirectToAction("Profile");
        }
    }
}
