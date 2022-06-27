using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services.JobService;
using WebApp.Services.UserService;
using System.Security.Principal;
using System.Security.Claims;
using WebApp.Services.CVService;
using WebApp.Models.RequestModel;
using WebApp.Models.ViewModel;
using WebApp.Services.AppliedService;
using WebApp.Constant;

namespace WebApp.Controllers
{
    public class ApplyController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IJobService _jobService;
        private readonly ICVService _cvService;
        private readonly IAppliedService _appliedService;

        public ApplyController(
            IUserService userService,
            UserManager<User> userManager,
            IJobService jobService,
            ICVService cvService,
            IAppliedService appliedService)
        {
            _userManager = userManager;
            _userService = userService;
            _cvService = cvService;
            _jobService = jobService;
            _appliedService = appliedService;
        }

        public async Task<IActionResult> Apply(int jobId)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var cv = await _cvService.GetByEmpId(userid);
            var job = await _jobService.GetById(jobId);
            var viewmodel = new ApplyViewModel()
            {
                Cv = cv.DataSet,
                Job = job.Data
            };
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Apply(int jobId, int cvId)
        {
            var result = await _appliedService.ApplyForJob(cvId, jobId);
            if(result.Success)
            {

                return RedirectToAction("AppliedJob", new { message = DisplayConstant.SUCCESS });
            }

            return RedirectToAction("AppliedJob", new { message = DisplayConstant.ERROR_ALREADY_APPLIED });
        }
        [Route("[controller]/[action]")]
        public async Task<IActionResult> AppliedJob(string message)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            ViewBag.Message = message;
            var appliedJobs = await _appliedService.GetAppliedByEmployee(userid);
            return View(appliedJobs.DataSet);
        }
        [Route("[controller]/[action]")]
        public async Task<IActionResult> AppliedCv(int id)
        {
            var applied = await _appliedService.GetAppliedByJob(id);

            return View(applied.DataSet);
        }
    }
}
