using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.CVService
{
    public interface ICVService
    {
        Task<Response<Cv>> GetAll();
        Task<Response<Cv>> GetByCvId(int id);
        Task<Response<Cv>> GetByEmpId(string empId);
        Task<Response<Cv>> UploadCv(string url);
        Task<Response<Cv>> RemoveCv(int id);
    }
}
