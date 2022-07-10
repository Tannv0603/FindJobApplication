using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.EmployerService
{
    public interface IEmployerService
    {
        Task<Response<Employer>> GetById(string id);
        Task<Response<Employer>> UpdateAsync(Employer employer);
    }
}
