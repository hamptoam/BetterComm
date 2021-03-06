﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BetterComm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BetterComm.Data;

namespace BetterComm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
             _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            var user =
                await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(false);

            if (user == null)
            {
                RedirectToAction("Login");
            }
            //login functionality  

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser appUser)
        {

            //login functionality  
            var user = await _userManager.FindByNameAsync(appUser.UserName);

            if (user != null)
            {
                //sign in  
                var signInResult = await _signInManager.PasswordSignInAsync
                                   (user, appUser.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Register");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser appUser)
        {
            //register functionality  

            var user = new ApplicationUser
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Name = appUser.Name,
                DateOfBirth = appUser.DateOfBirth,
                Password = appUser.Password
            };

            var result = await _userManager.CreateAsync(user, user.Password);


            if (result.Succeeded)
            {
                // User sign  
                // sign in   
                var signInResult = await _signInManager.PasswordSignInAsync
                                   (user, user.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var appUser = new ApplicationUser { }; 

            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser.Email,
                   appUser.Password, appUser.RememberMe,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new
                    {
                        ReturnUrl = returnUrl,
                        appUser.RememberMe
                    });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public async Task<IActionResult> LogOut(string username, string password)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}

      
    

