using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using WebApp.Models.DTOs;
using WebApp.Models.RequestModel;

namespace WebApp.Services.UserService
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private IMapper _mapper;

       
    }
}
