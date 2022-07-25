using DAL.Entities;
using DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.RequestModel;
using WebApp.Services.UserService;
using WebApp.Constant;

namespace WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
       
        public UserController(IConfiguration config,
            IUserService userService,
            UserManager<User> userManager,
            SignInManager<User> signManager)
        {
            _userManager = userManager;
            _userService = userService;
            _signInManager = signManager;
            _configuration = config;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn
            (UserLoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if(user == null)
            {
                ViewData["error"] = "Username not exist!";
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Job");
                
            }
              
            ViewData["error"] = "Username or password Incorrect!";
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Job");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserRegisterRequest request)
        {
            if(request.ConfirmPassword!=request.Password)
            {
                ViewData["error"] = "Confirm password unmatch!";
                return View();
            }
            if(ModelState.IsValid) 
            {
                if (request.TypeUser == "Employer") request.TypeUser = "2";
                if (request.TypeUser == "Employee") request.TypeUser = "1";
                var userEmail = await _userManager.FindByEmailAsync(request.Email);
                var userName = await _userManager.FindByNameAsync(request.UserName);
                if (userEmail == null && userName==null)
                {
                   var result = await _userService.CreateAsync(request);
                    if(result.Success) return RedirectToAction("SignIn", "User");
                }
                else
                {
                    ViewData["error"] = "Already Exist Username or Email";
                    return View();
                }
            }
            ViewData["error"] = "Invalid Request";
             return View();
        }
        public async Task<IActionResult> UpdateProfile()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            if (userid == null)
                return RedirectToAction("Signin", "User");
            var user = await _userManager.GetUserAsync(User);
            if (user.TypeUser == TypeUser.Employee)
                return RedirectToAction("UpdateProfile", "Employee");
            if (user.TypeUser == TypeUser.Employer)
                return RedirectToAction("UpdateProfile", "Employer");
            return View();
        }
        
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var userid = _userManager.GetUserId(currentUser);
            if (userid == null)
                return RedirectToAction("Signin", "User");
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userManager.ChangePasswordAsync(user,request.OldPassword,request.NewPassword);
                if (result.Succeeded) ViewBag.result = "Successfully changed!";
                else ViewBag.result = "Unsuccessfully!";
            }
            return View();
        }
    }
}
