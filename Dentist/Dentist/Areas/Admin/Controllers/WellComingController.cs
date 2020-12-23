using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Extentions;
using Dentist.Helper;
using Dentist.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WellComingController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public WellComingController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            WellComing wellComing = _db.WellComings.FirstOrDefault();
            return View(wellComing);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            WellComing wellComing = _db.WellComings.Find(id);
            if (wellComing == null) return NotFound();
            return View(wellComing);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,WellComing wellComing)
        {
            if (id == null) return NotFound();
            WellComing dbWellComing = _db.WellComings.Find(id);
            if (dbWellComing == null) return NotFound();
            if (wellComing.Photo != null)
            {
                if (!wellComing.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil formatinda file sechin");
                    return View();
                }
                if (wellComing.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("Photo", "Shekilin olcusu 1600kb-dan az olmalidir");
                    return View();
                }
                Helpers.DeleteImg(_env.WebRootPath, "images", dbWellComing.Image);
                dbWellComing.Image = await wellComing.Photo.SaveImage(_env.WebRootPath, "images");
                dbWellComing.Description = wellComing.Description;
                dbWellComing.WelcomeTitle = wellComing.WelcomeTitle;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "WellComing");
            }
            dbWellComing.Description = wellComing.Description;
            dbWellComing.WelcomeTitle = wellComing.WelcomeTitle;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "WellComing");

        }

    }
}