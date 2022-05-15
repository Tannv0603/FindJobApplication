using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Services.CityServices
{
    public interface ICityService
    {
        City GetCityByID(int id);
        IEnumerable<City> GetAll();
    }
}
