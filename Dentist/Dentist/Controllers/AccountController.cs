//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Dentist.DAL;
//using Dentist.Helper;
//using Dentist.Models;
//using Dentist.ViewModels;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace Dentist.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserManager<AppUser> _userManager;
//        private readonly SignInManager<AppUser> _signInManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
//            RoleManager<IdentityRole> roleManager)
//        {
//            _signInManager = signInManager;
//            _userManager = userManager;
//            _roleManager = roleManager;
//        }
       
//        public IActionResult Login()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(LoginVM login)
//        {
//            if (!ModelState.IsValid) return View(login);
         
//            AppUser loginUser = await _userManager.FindByEmailAsync(login.Email);
//            if (loginUser == null)
//            {
//                ModelState.AddModelError("", "Qeydiyyatdan kech");
//                return View(login);
//            }
//            Microsoft.AspNetCore.Identity.SignInResult signinResult =await _signInManager.PasswordSignInAsync(loginUser, login.Password,false,true);
//            if (!signinResult.Succeeded)
//            {
//                ModelState.AddModelError("", "Qeydiyyatdan kech");
//                return View(login);
//            }
//            return RedirectToAction("Index", "Blog",new { area="admin"});


//        }
       
//        public async Task CreateRole()
//        {
//            if (!await _roleManager.RoleExistsAsync(Helpers.UserRoles.Admin.ToString()))
//            {
//                await _roleManager.CreateAsync(new IdentityRole(Helpers.UserRoles.Admin.ToString()));
//            }

//        }
//    }
//}