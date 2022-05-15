using System.Collections.Generic;
using DAL.Repository;
using DAL.Entities;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WinFormsApp.Services.CityServices
{
   public class CityServices:ICityService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString;
        private readonly CityRepository _cityRepository;
       
        public CityServices()
        {
            var options = new DbContextOptionsBuilder<FindingJobContext>();
            string connection = ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString;
            options.UseSqlServer(connection);
            _cityRepository = _cityRepository = new CityRepository(
               new FindingJobContext(options.Options));
        }

        public City GetCityByID(int id)
        {
            return _cityRepository.DbSet.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            return _cityRepository.DbSet.ToList();
        }
    }
}
