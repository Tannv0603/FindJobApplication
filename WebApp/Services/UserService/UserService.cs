using AutoMapper;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using WebApp.Constant;
using WebApp.Models.RequestModel;
using WebApp.Models.Response;

namespace WebApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(UserManager<User> userManager,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _userRepository= userRepository;
            _unitOfWork= unitOfWork;
            _mapper= mapper;
            _contextAccessor= contextAccessor;
        }
        public async Task<Response<User>> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (user == null)
            {
                return new Response<User>(false, data: null, DisplayConstant.ERROR_UNAUTHENTICATED);
            }
            return new Response<User>(true, user,DisplayConstant.SUCCESS);
        }
       
    }
}
