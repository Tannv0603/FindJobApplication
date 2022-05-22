using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.SkillService
{
    public interface ISkillService
    {
        Task<Response<Skill>> GetAll();
        Task<Response<Skill>> GetById(int id);
        Task<Response<Skill>> GetByName(string Name);
    }
}
