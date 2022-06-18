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

namespace WebApp.Controllers
{
    public class ApplyController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly JobService _jobService;
        private readonly CVService _cvService;

        public ApplyController(
            IUserService userService,
            UserManager<User> userManager,
            JobService jobService,
            CVService cvService)
        {
            _userManager = userManager;
            _userService = userService;
            _cvService = cvService;
            _jobService = jobService;
        }

        public async Task<IActionResult> Apply(int jobId)
        {
            var job = _jobService.GetById(jobId);
            var user = await _userManager.GetUserAsync(User);
            var cv = await _cvService.GetByEmpId(user.Id);
            return View(cv.DataSet);
        }

        [HttpPost]
        public async Task<IActionResult> Apply(ApplyRequest request)
        {

            return View();
        }
    }
}
