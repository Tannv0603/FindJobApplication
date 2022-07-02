using DAL.Entities;
using System.Collections.Generic;

namespace WebApp.Models.ViewModel
{
    public class JobDetailViewModel
    {
        public Job JobData { get; set; }
        public IEnumerable<Review>? Reviews {get; set;}
        public double AvgScore { get; set;}

    }
}
