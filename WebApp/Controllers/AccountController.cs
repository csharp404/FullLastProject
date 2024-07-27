using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{

    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUser user)
        {
            AppUser usr = new AppUser { UserName = user.Email };//use auto mapper
            var res = await userManager.CreateAsync(usr, user.Password);
            if (res.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser user)
        {
        AppUser usr = new AppUser { UserName= user.Email };
            var res =await signInManager.PasswordSignInAsync(usr.UserName, user.Password,false,false);
            if (res.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

    }
}