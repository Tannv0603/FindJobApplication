using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult HRPost()
        {
            return View();
        }
        public IActionResult JobManagement()
        {
            return View();
        }
        public IActionResult DetailListCv()
        {
            return View();
        }
    }
}
