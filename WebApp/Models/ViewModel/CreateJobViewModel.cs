using DAL.Entities;
using System.Collections.Generic;

namespace WebApp.Models.ViewModel
{
    public class CreateJobViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<JobTitle> Titles { get; set; }
    }
}
