using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.Response;

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
        public async Task<Response<City>> GetAll()
        {
          var cities = await _cityRepository.DbSet.ToListAsync();
            if(cities == null)
            {
                return new Response<City>(false, dataset: null, DisplayConstant.ERROR_LOADFAIL);
            }
         return new Response<City>(true,cities,DisplayConstant.SUCCESS);
        }

        public async Task<Response<City>> GetById(int id)
        {
            var city = await _cityRepository.DbSet.FirstOrDefaultAsync(c => c.CityId==id);
            if (city == null)
            {
                return new Response<City>(false, data: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<City>(true, city, DisplayConstant.SUCCESS);
        }
    }
}
