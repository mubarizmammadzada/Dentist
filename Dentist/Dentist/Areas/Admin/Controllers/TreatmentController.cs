using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Extentions;
using Dentist.Helper;
using Dentist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class TreatmentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public TreatmentController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Treatment> treatments = _db.Treatments.OrderByDescending(t => t.Id).ToList();
            return View(treatments);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Treatment treatment)
        {
            if (!treatment.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (treatment.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb dan chox olmamalidir");
                return View();
            }
            treatment.Image = await treatment.Photo.SaveImage(_env.WebRootPath, "images");
            treatment.Slug = SlugGenerator.SlugGenerator.GenerateSlug(treatment.TreatmentName);
            await _db.Treatments.AddAsync(treatment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Treatment");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Treatment treatment = _db.Treatments.Find(id);
            if (treatment == null) return NotFound();
            return View(treatment);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Treatment treatment)
        {
            if (id == null) return NotFound();
            Treatment dbTreatment = _db.Treatments.Find(id);
            if (dbTreatment == null) return NotFound();
            if (treatment.Photo != null)
            {
                if (!treatment.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil sechin");
                    return View();
                }
                if (treatment.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu 1600 kbdan chox olmalidir");
                    return View();
                }
                Helpers.DeleteImg(_env.WebRootPath, "images", dbTreatment.Image);
                dbTreatment.Image = await treatment.Photo.SaveImage(_env.WebRootPath, "images");
                dbTreatment.About = treatment.About;
                dbTreatment.TreatmentName = treatment.TreatmentName;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Treatment");

            }
            dbTreatment.About = treatment.About;
            dbTreatment.TreatmentName = treatment.TreatmentName;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Treatment");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Treatment treatment = _db.Treatments.Find(id);
            if (treatment == null) return NotFound();
            return View(treatment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Treatment treatment = _db.Treatments.Find(id);
            if (treatment == null) return NotFound();
            Helpers.DeleteImg(_env.WebRootPath, "images", treatment.Image);
            _db.Treatments.Remove(treatment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","Treatment");
        }
    }
}