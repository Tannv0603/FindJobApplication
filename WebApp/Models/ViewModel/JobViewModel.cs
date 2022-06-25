using DAL.Entities;
using System.Collections.Generic;

namespace WebApp.Models.ViewModel
{
    public class JobViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
        public FilterViewModel Filter { get; set; }

        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<JobTitle> Titles { get; set; }
    }
}
