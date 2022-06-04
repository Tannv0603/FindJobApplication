using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.CloudService
{
    public interface ICloudService
    {
        Task<bool> AddCv();
        Task<bool> AddImage();
        Task<bool> DeleteCv();
        Task<bool> DeleteImage();
    }
}
