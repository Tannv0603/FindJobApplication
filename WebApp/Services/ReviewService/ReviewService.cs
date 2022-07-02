using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.Response;
using WebApp.Models.ViewModel;
using WebApp.Services.JobService;

namespace WebApp.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJobService _jobService;
        public ReviewService(IReviewRepository reviewRepository
            , IUnitOfWork unitOfWork
            , IJobService jobService)
        {
           _reviewRespository = reviewRepository;
            _unitOfWork = unitOfWork;
            _jobService = jobService;   

        }
        public async Task<Response<Review>> AddReview(NewReview newReview)
        {
            var currentJob = await _jobService.GetById(newReview.JobId);
            if (newReview.UserId == currentJob.Data.EmployerId)
                return new Response<Review>()
                {
                    Success = false,
                    Message = DisplayConstant.ERROR_BADREQUEST
                };
            else
            {
                try
                {
                    var review = new Review()
                    {
                        Rating = newReview.Rating,
                        Comment = newReview.Content,
                        JobId = newReview.JobId,
                        UserId  =  newReview.UserId,
                        Date = System.DateTime.Now
                    };
                    var result = await _reviewRespository.DbSet.AddAsync(review);
                    _unitOfWork.SaveChanges();
                    return new Response<Review>()
                    {
                        Success = true,
                        Message = DisplayConstant.SUCCESS_CREATED
                    };
                }
                catch
                {
                    return new Response<Review>()
                    {
                        Success = false,
                        Message = DisplayConstant.ERROR_CREATED
                    };
                }
            }
        }

        public async Task<Response<Review>> GetAll(int jobid)
        {
            var rv = await _reviewRespository.DbSet
             .AsNoTracking()
             .Where(rv => rv.JobId == jobid)
             .Include(rv => rv.User)
             .Include(rv => rv.Job)
             .ToListAsync();
            return new Response<Review>()
            {
                DataSet = rv,
                Message = DisplayConstant.SUCCESS,
                Success = true
            };
        }
    }
}
