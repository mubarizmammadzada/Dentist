using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(AppDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser loginUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Username = loginUser.UserName;
            }
            Bio bios = _db.Bios.FirstOrDefault();
            return View(await Task.FromResult(bios));
        }
    }
}
