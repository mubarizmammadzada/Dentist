using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dentist.Areas.Admin.ViewModels;
using Dentist.DAL;
using Dentist.Extentions;
using Dentist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class CertificateController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public CertificateController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Certificate> Certificates = _db.Certificates.OrderByDescending(c => c.Id).Take(8).ToList();
            return View(Certificates);
        }

        public IActionResult Create()
        {
            DoctorVM doctorVM = new DoctorVM
            {
                Doctors = _db.Doctors.ToList()
            };
            return View(doctorVM);

        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorVM doctorVM)
        {
            if (doctorVM.Certificate.Photo == null)
            {
                ModelState.AddModelError("", "Shekil Sechin");
                return View();
            }
            if (!doctorVM.Certificate.Photo.IsImage())
            {
                ModelState.AddModelError("", "Shekil formatinda bir file sechin");
                return View();
            }
            if (doctorVM.Certificate.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("", "Shekilin olchusu 1600kb-dan chox ola bilmez");
                return View();
            }
            Certificate certificate = new Certificate();
            certificate.Image = await doctorVM.Certificate.Photo.SaveImage(_env.WebRootPath, "images");
            string selectedDoctor = Request.Form["doctors"];
            Doctor doctor = _db.Doctors.FirstOrDefault(d => d.FullName.ToLower().Trim() == selectedDoctor.Trim().ToLower());
            certificate.DoctorId = doctor.Id;
            await _db.Certificates.AddAsync(certificate);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Certificate");




        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            DoctorVM doctorVM = new DoctorVM
            {
                Certificate = _db.Certificates.Include(d => d.Doctor).FirstOrDefault(d => d.Id == id),

                Doctors = _db.Doctors.ToList()

            };


            return View(doctorVM);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, DoctorVM doctorVM)
        {
            if (id == null) return NotFound();
            Certificate certificate = _db.Certificates.Find(id);

            if (certificate == null) return NotFound();
            if (doctorVM.Certificate != null)
            {
                if (!doctorVM.Certificate.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Shekil sechin");
                    return View();
                }
                if (doctorVM.Certificate.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("", "Shekilin olchusu 1600kb-dan chox ola bilmez");
                    return View();
                }
                Helper.Helpers.DeleteImg(_env.WebRootPath, "images", certificate.Image);
                certificate.Image = await doctorVM.Certificate.Photo.SaveImage(_env.WebRootPath, "images");
                string selectedDoctor = Request.Form["doctors"];
                Doctor doctor = _db.Doctors.FirstOrDefault(d => d.FullName.Trim().ToLower() == selectedDoctor.ToLower().Trim());
                certificate.DoctorId = doctor.Id;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Certificate");
            }
            string selectedDoctorr = Request.Form["doctors"];
            Doctor doctorr = _db.Doctors.FirstOrDefault(d => d.FullName.Trim().ToLower() == selectedDoctorr.ToLower().Trim());
            certificate.DoctorId = doctorr.Id;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Certificate");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Certificate certificate = _db.Certificates.Find(id);
            if (certificate == null) return NotFound();
            return View(certificate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Certificate certificate = _db.Certificates.Find(id);
            if (certificate == null) return NotFound();
            Helper.Helpers.DeleteImg(_env.WebRootPath, "images", certificate.Image);
            _db.Certificates.Remove(certificate);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Certificate");
        }
    }
}