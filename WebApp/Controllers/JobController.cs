using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models;
using WebApp.Models.ViewModel;
using WebApp.Services.CityService;
using WebApp.Services.JobService;
using WebApp.Services.JobTitleService;
using WebApp.Services.ReviewService;
using WebApp.Services.UserService;

namespace WebApp.Controllers
{
    public class JobController:Controller 
    {
        private readonly IJobService _jobService;
        private readonly ICityService _cityService;
        private readonly IJobTitleService _jobTitleService;
        private readonly IReviewService _reviewService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        public JobController(IJobService jobService
            ,ICityService cityService
            ,IJobTitleService jobTitleService
            ,IReviewService reviewService
            ,IUserService userService
            , UserManager<User> userManager)
        {
            _jobTitleService = jobTitleService;
            _reviewService = reviewService;
            _jobService = jobService;
            _cityService = cityService;
            _userManager = userManager;
            _userService = userService;
        }
        
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAll();
            var cities = await _cityService.GetAll();
            var titles = await _jobTitleService.GetAll();
            if (jobs.Success)
                return View(new JobViewModel { Jobs = jobs.DataSet, Cities = cities.DataSet, Titles = titles.DataSet});        
            return View("Error", new ErrorViewModel() { RequestId = jobs.Message });
        }
        public async Task<IActionResult> Detail(short id)
        {
            var job = await _jobService.GetById(id);
            var reviews = await _reviewService.GetAll(id);
            double rating = 0;
            foreach (var review in reviews.DataSet)
            {
                rating += review.Rating;
            }
            var viewModel = new JobDetailViewModel
            {
                JobData = job.Data,
                Reviews = reviews.DataSet,
                AvgScore =  reviews.DataSet.Count()==0 ? 0: rating/reviews.DataSet.Count()
            };
            ViewBag.Reviews = reviews.DataSet;
            ViewBag.AvgScore = rating / reviews.DataSet.Count();
            if(job.Success) return View(viewModel);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Rating(RatingModel RatingModel, short jobId)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            var job = await _jobService.GetById(jobId);
            if(job.Data.EmployerId == userid)
            {
                return RedirectToAction("Detail", new { id = jobId });
            }            
            int score = RatingModel.IsOne ? 1 : RatingModel.IsTwo ? 2 : RatingModel.IsThree ? 3 : RatingModel.IsFour ? 4 : 5;
            var review = await _reviewService.AddReview(
                    new NewReview() { 
                        Content = RatingModel.Comment, 
                        Rating = score, JobId = jobId, 
                        UserId = userid 
                    }
                );
            return RedirectToAction("Detail",new { id=jobId });
        }
        public async Task<IActionResult> Filter(FilterViewModel filter)
        {
            var jobs = await _jobService.GetAll();
            var cities = await _cityService.GetAll();
            var titles = await _jobTitleService.GetAll();
            var searchText =(filter.SearchFilter +"").ToLower().Trim();
            var result = jobs.DataSet
                .Where(j =>                    
                    (j.StartSalary >= filter.StartSalary && j.EndSalary <= filter.EndSalary)
                    && (j.City.CityName == filter.City || filter.City == null)
                    && (j.JobTitle.TitleName == filter.JobTitle || filter.JobTitle == null)
                    && ((j.JobType == JobType.FullTime&& filter.IsFullTime)
                        || (j.JobType == JobType.Freelancer && filter.IsFreeLance)
                        || (j.JobType == JobType.PartTime && filter.IsPartTime)
                        || (j.JobType == JobType.Internship && filter.IsInternship))
                    && (j.JobName.Contains(searchText)
                        || j.JobName.ToLower().Contains(searchText)
                        || j.JobTitle.TitleName.ToLower().Contains(searchText)
                        || j.Tags.ToLower().Contains(searchText))
                    )
                .ToList();
            switch(filter.SortBy)
            {
                case SortBy.Salary: result.OrderByDescending(j => j.StartSalary); break;
                case SortBy.Date: result.OrderByDescending(j => j.StartDate); break;
                default: result.OrderByDescending(j => j.StartDate); break;
            }
            return View("Index",new JobViewModel { Jobs = result, Cities = cities.DataSet, Titles = titles.DataSet });
        }
    }
}
