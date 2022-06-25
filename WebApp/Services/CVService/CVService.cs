using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.Response;

namespace WebApp.Services.CVService
{
    public class CVService : ICVService
    {
        private readonly ICvRepository _cvRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeAppliedForJobRepository _appliedRepository;
        public CVService(
            ICvRepository cvRepository
            , IUnitOfWork unitOfWork
            , IEmployeeAppliedForJobRepository applied)
        {
            _cvRepository = cvRepository;
            _unitOfWork = unitOfWork;
            _appliedRepository = applied;   

        }
        public Task<Response<Cv>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> GetByCvId(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<Cv>> GetByEmpId(string empId)
        {
            var cvs = await _cvRepository.DbSet
                .Where(cv => cv.EmployeeId == empId)
                .Include(cv => cv.Employee).ThenInclude(emp => emp.EmployeeNavigation)
                .ToListAsync();
            return new Response<Cv>()
            {
                DataSet = cvs,
                Message = DisplayConstant.SUCCESS,
                Success = true
            };
        }

        

        public Task<Response<Cv>> RemoveCv(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> UploadCv(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}
