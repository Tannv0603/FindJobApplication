using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.Response;

namespace WebApp.Services.SkillService
{
    public class SkillService : ISkillService
    {

        private readonly ISkillRepository _skillRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SkillService(ISkillRepository skillRepository
            , IUnitOfWork unitOfWork
            )
        {
            _skillRepository = skillRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Skill>> GetAll()
        {
            var skills = await _skillRepository.DbSet
                .AsNoTracking()
                .Include(j=>j.Jobs)
                .ToListAsync();
            if (skills == null)
            {
                return new Response<Skill>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<Skill>(true, dataset: skills, DisplayConstant.SUCCESS);
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
