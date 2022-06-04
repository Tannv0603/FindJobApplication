﻿using DAL.Entities;
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

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        
        public UserController(IConfiguration config,
            IUserService userService,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _userService = userService;
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
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);
                HttpContext.Session.SetString("Token", token.ToString());
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Error");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserRegisterRequest request)
        {
            if(ModelState.IsValid)
            {
                if (request.TypeUser == "Employer") request.TypeUser = "2";
                if (request.TypeUser == "Employee") request.TypeUser = "1";
                var user = await _userService.GetByEmail(request.Email);
                if (user.Data == null)
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
        
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
