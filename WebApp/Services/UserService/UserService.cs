using AutoMapper;
using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployerRepository _employerRepository;
        public UserService(UserManager<User> userManager,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor contextAccessor,
            IEmployeeRepository employeeRepository,
            IEmployerRepository employerRepository,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            _employeeRepository = employeeRepository;
            _employerRepository = employerRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<Response<User>> CreateAsync(UserRegisterRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
                AvatarUrl = MediaConstant.DEFAULT_USER_AVATAR,
                TypeUser = short.Parse(request.TypeUser),
                FullName = request.FullName
            };
            await _userManager.CreateAsync(user).ConfigureAwait(false);
            var created = await GetByEmail(request.Email);
            if (created.Data != null)
            {
                if (short.Parse(request.TypeUser) == TypeUser.Employee)
                {
                    var result = await CreateEmployeeAsync(created.Data.Id);
                    if (!result)
                    {
                        return new Response<User>(false, created.Data, DisplayConstant.ERROR);
                    }
                    var role =await _roleManager.FindByNameAsync(UserRoles.Employee);
                    if (role == null) await _roleManager.CreateAsync(new IdentityRole() { Name = UserRoles.Employee }).ConfigureAwait(false);
                    _unitOfWork.ClearTracked();
                    await _userManager.AddToRoleAsync(created.Data, UserRoles.Employee);
                }
                if (short.Parse(request.TypeUser) == TypeUser.Employer)
                {
                    var result = await CreateEmployerAsync(created.Data.Id);
                    if (!result) 
                    {
                        return new Response<User>(false, created.Data, DisplayConstant.ERROR);
                    }
                    var role = _roleManager.FindByNameAsync(UserRoles.Employer);
                    if (role == null) await _roleManager.CreateAsync(new IdentityRole() { Name = UserRoles.Employer }).ConfigureAwait(false);
                    _unitOfWork.ClearTracked();
                    
                    await _userManager.AddToRoleAsync(created.Data, UserRoles.Employer);
                }
                return new Response<User>(true, created.Data, DisplayConstant.SUCCESS_CREATED);
            }
            else
            {
                return new Response<User>(false, data: null, DisplayConstant.ERROR_CREATED);
            }
        }

        private async Task<bool> CreateEmployerAsync(string id)
        {
            try
            {
                Employer employer = new Employer() { EmployerId = id, CompanyName="" };
                await _employerRepository.DbSet.AddAsync(employer).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> CreateEmployeeAsync(string id)
        {
            try
            {
                Employee employee = new Employee() { EmployeeId = id, Address="",CityId=0,DateOfBirth=DateTime.Now };
                await _employeeRepository.DbSet.AddAsync(employee).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public async Task<Response<User>> GetByEmail(string email)
        {
            var user = await _userRepository.DbSet.AsNoTracking()
                          .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return new Response<User>(false, data: null, DisplayConstant.ERROR_LOADFAIL);
            }
            return new Response<User>(true, user, DisplayConstant.SUCCESS);
        }

        public async Task<Response<User>> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (user == null)
            {
                return new Response<User>(false, data: null, DisplayConstant.ERROR_UNAUTHENTICATED);
            }
            return new Response<User>(true, user, DisplayConstant.SUCCESS);
        }

    }
}
