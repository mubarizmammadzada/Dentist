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
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public SliderController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            int count = _db.Sliders.Count();
            if (count > 5)
            {
                ModelState.AddModelError("Photo", "Shekillerin sayi 5-den chox ola bilmez");
                return View();
            }
            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (slider.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb-dan boyuk ola bilmez");
                return View();
            }
            slider.Image = await slider.Photo.SaveImage(_env.WebRootPath, "images");
            Slider slider1 = new Slider();
            slider1.Image = slider.Image;
            slider1.SliderDescription = slider.SliderDescription;
            slider1.SliderTitle = slider.SliderTitle;
            await _db.Sliders.AddAsync(slider1);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Slider");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _db.Sliders.Find(id);
            if (slider == null) return NotFound();
            return View(slider);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _db.Sliders.Find(id);
            if (slider == null) return NotFound();
            Helpers.DeleteImg(_env.WebRootPath, "images", slider.Image);
            _db.Sliders.Remove(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Slider");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _db.Sliders.Find(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Slider slider)
        {
            if (id == null) return NotFound();
            Slider dbSlider = await _db.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();
            if (slider.Photo != null)
            {
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil formatinda bir file sechin");
                    return View();
                }
                if (slider.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb-dan boyuk olmalidir");
                    return View();
                }
                
                Helpers.DeleteImg(_env.WebRootPath, "images", dbSlider.Image);
                dbSlider.Image = await slider.Photo.SaveImage(_env.WebRootPath, "images");
                dbSlider.SliderDescription = slider.SliderDescription;
                dbSlider.SliderTitle = slider.SliderTitle;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Slider");
            }
            dbSlider.SliderDescription = slider.SliderDescription;
            dbSlider.SliderTitle = slider.SliderTitle;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Slider");
        }
    }
}