using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.CloudService
{
    public interface ICloudService
    {
        public string AddImage(IFormFile file);
        public string  AddCV(IFormFile file);
    }
}
