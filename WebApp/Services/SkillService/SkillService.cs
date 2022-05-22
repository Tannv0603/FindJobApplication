using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.SkillService
{
    public class SkillService : ISkillService
    {
        public Task<Response<Skill>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Skill>> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Skill>> GetByName(string Name)
        {
            throw new System.NotImplementedException();
        }
    }
}
