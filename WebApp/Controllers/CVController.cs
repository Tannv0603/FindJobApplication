using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.ViewModel;
using WebApp.Services.AppliedService;
using WebApp.Services.CloudService;
using WebApp.Services.CVService;

namespace WebApp.Controllers
{
    public class CVController : Controller
    {
        private readonly ICVService _cvService;
        private readonly IAppliedService _appliedService;
        private readonly ICloudService _cloudService;
        private readonly UserManager<User> _userManager;
        public CVController(
            ICVService cvService
            ,IAppliedService appliedService
            , ICloudService cloudService
            , UserManager<User> userManager)
        {
            _cvService = cvService;
            _userManager =userManager;
            _cloudService = cloudService;
            _appliedService = appliedService;
        }
        public async Task<IActionResult> EmployerCV(short jobid)
        {
            var cvs = await _appliedService.GetAppliedByJob(jobid);
            return View(cvs.DataSet);
        }
        public async Task<IActionResult> EmployeeCV()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var cvs = await _cvService.GetByEmpId(userid);
            return View(cvs.DataSet);
        }
        public async Task<IActionResult> AddCv(IFormFile file, string filename)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var path = _cloudService.AddCV(file);
            var cv = new Cv()
            {
                CvName = filename,
                StoredUrl = path.Url.ToString(),
                EmployeeId = userid,
                Weight = path.Bytes/1048576,
            };
           var result = await _cvService.UploadCv(cv);
            if (result.Success) ViewBag.Success = DisplayConstant.SUCCESS_CREATED;
            else ViewBag.Error = DisplayConstant.ERROR_CREATED;
            return RedirectToAction("EmployeeCV");
        }
    }
}
