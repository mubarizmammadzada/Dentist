using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Dentist.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            AppUser newUser = new AppUser()
            {
                Email = registerVM.Email,
                UserName=registerVM.Username,
                PasswordHash=registerVM.Password
            };
            IdentityResult identityResult =await _userManager.CreateAsync(newUser,newUser.PasswordHash);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
            await _signInManager.SignInAsync(newUser, true);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);
            AppUser loginUser = await _userManager.FindByEmailAsync(login.Email);
            if (loginUser == null)
            {
                ModelState.AddModelError("", "Qeydiyyatdan kech");
                return View(login);
            }
            var signinResult = await _signInManager.PasswordSignInAsync(loginUser, login.Password, false, true);
            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", "Qeydiyyatdan kech");
                return View(login);
            }

            return Content("Yes");
        }
    }
}