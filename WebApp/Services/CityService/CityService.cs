using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CityService(ICityRepository cityRepository
            , IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<City>> GetAll()
        {
          return await _cityRepository.DbSet.ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
           return await _cityRepository.DbSet.FindAsync(id);
        }
    }
}
