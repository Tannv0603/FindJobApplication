using DAL.Entities;
using System;
using System.Collections.Generic;

namespace WebApp.Models.ViewModel
{
    public class AddJobViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<JobTitle> Titles { get; set; }
       
        public NewJob NewJob { get; set; }
    }
}
