using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
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
