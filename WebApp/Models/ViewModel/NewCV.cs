using Microsoft.AspNetCore.Http;

namespace WebApp.Models.ViewModel
{
    public class NewCV
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }

    }
}
