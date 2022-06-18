using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Profile()
        {
            return View();
        }
    }
}
