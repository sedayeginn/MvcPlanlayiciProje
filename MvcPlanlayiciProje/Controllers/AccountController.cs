using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcPlanlayiciProje.Data.Entities;
using MvcPlanlayiciProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPlanlayiciProje.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "kullanıcı bulunamadı!");
                return View(vm);

            }
            var result =await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "oturum açarken hata oluştu");
            return View(vm);
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(HomeViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            ApplicationUser user = new ApplicationUser()
            {
                UserName = vm.UserName,
                Name = vm.Name,
                SurName = vm.SurName,
                Email = vm.Email,
                PasswordHash=vm.Password
            };
           var result= _userManager.CreateAsync(user, vm.Password).Result;
            if(result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();

        }
    }
}
