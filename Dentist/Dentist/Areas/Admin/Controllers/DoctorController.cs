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
    public class DoctorController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public DoctorController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Doctor> doctors = _db.Doctors.OrderByDescending(d => d.Id).ToList();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!doctor.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (doctor.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb-dan boyuk ola bilmez");
                return View();
            }
            doctor.Image =await doctor.Photo.SaveImage(_env.WebRootPath, "images");
            await _db.Doctors.AddAsync(doctor);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Doctor");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Doctor doctor = _db.Doctors.Find(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Doctor doctor)
        {
            if (id == null) return NotFound();
            Doctor dbDoctor = _db.Doctors.Find(id);
            if (dbDoctor == null) return NotFound();
            if (doctor.Photo != null)
            {
                if (!doctor.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil sechin");
                    return View();
                }
                if (doctor.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb-dan boyuk ola bilmez");
                    return View();
                }
                Helpers.DeleteImg(_env.WebRootPath, "images", dbDoctor.Image);
                dbDoctor.Image = await doctor.Photo.SaveImage(_env.WebRootPath, "images");
                dbDoctor.About = doctor.About;
                dbDoctor.Facebook = doctor.Facebook;
                dbDoctor.FullName = doctor.FullName;
                dbDoctor.Gmail = doctor.Gmail;
                dbDoctor.Instagram = doctor.Instagram;
                dbDoctor.Position = doctor.Position;
                dbDoctor.Profession = doctor.Profession;
                dbDoctor.Twitter = doctor.Twitter;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Doctor");

            }
            dbDoctor.About = doctor.About;
            dbDoctor.Facebook = doctor.Facebook;
            dbDoctor.FullName = doctor.FullName;
            dbDoctor.Gmail = doctor.Gmail;
            dbDoctor.Instagram = doctor.Instagram;
            dbDoctor.Position = doctor.Position;
            dbDoctor.Profession = doctor.Profession;
            dbDoctor.Twitter = doctor.Twitter;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Doctor");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Doctor doctor = _db.Doctors.Find(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Doctor doctor = _db.Doctors.Find(id);
            if (doctor == null) return NotFound();
            Helpers.DeleteImg(_env.WebRootPath, "image", doctor.Image);
            _db.Doctors.Remove(doctor);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Doctor");
        }
    }
}