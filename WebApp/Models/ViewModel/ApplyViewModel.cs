using DAL.Entities;
using System.Collections.Generic;

namespace WebApp.Models.ViewModel
{
    public class ApplyViewModel
    {
        public IEnumerable<Cv> Cv { get; set; }
        public Job Job { get; set; }
    }
}
