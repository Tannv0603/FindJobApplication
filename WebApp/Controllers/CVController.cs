using Microsoft.AspNetCore.Mvc;
using WebApp.Services.CVService;

namespace WebApp.Controllers
{
    public class CVController : Controller
    {
        private readonly ICVService _cvService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
