

namespace WebApp.Models.ViewModel
{
    public class FilterViewModel
        
    {
        //filter for salary
      public decimal? StartSalary { get; set; }
        public decimal? EndSalary { get; set; }
        //filter for search text
        public string? SearchFilter { get; set; }
        public int? JobType { get; set; }

        //filter for job Type
        public bool IsFullTime { get; set; }

        public bool IsPartTime { get; set; }

        public bool IsFreeLance { get; set; }

        public bool IsInternship { get; set; }
        //sort
        public string? SortBy { get; set; }
        //fiter by city
        public string? City { get; set; }
        //filter by Title
        public string? JobTitle { get; set; }


    }
}
