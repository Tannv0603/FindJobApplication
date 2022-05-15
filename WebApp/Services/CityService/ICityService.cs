using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services.CityService
{
    public interface ICityService
    {
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetAll();

    }
}
