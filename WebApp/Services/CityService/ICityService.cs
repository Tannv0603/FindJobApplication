using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.CityService
{
    public interface ICityService
    {
        Task<Response<City>> GetById(int id);
        Task<Response<City>> GetAll();
        Task<Response<City>> GetByName(string name);
    }
}
