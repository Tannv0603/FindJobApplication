using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;
using WebApp.Models.ViewModel;

namespace WebApp.Services.ReviewService
{
    public interface IReviewService
    {
        Task<Response<Review>> GetAll(int jobid);
        Task<Response<Review>> AddReview(NewReview newReview);
    }
}
