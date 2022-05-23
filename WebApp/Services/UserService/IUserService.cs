using DAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;

namespace WebApp.Services.UserService
{
    public interface IUserService
    {
        Task<Response<User>> GetCurrentUserAsync();
        Task<Response<User>> GetByEmail(string email);
        Task<Response<User>> CreateAsync(UserRegisterRequest request);
    }
}
