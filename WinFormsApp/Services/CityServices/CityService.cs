using System.Collections.Generic;
using DAL.Repository;
using DAL.Entities;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp.Services.CityServices
{
   public class CityServices:ICityService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FindingJobDbContext"].ConnectionString;
        private readonly CityRepository _cityRepository;
       
        public CityServices()
        {
            var options = new DbContextOptionsBuilder<FindingJobContext>();
            string connection = ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString;
            options.UseSqlServer(connection);
            _cityRepository = _cityRepository = new CityRepository(
               new FindingJobContext(options.Options));
        }
    }
}
