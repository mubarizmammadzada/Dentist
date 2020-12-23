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
    public class PatientController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public PatientController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Patient> patients = _db.Patients.Take(10).OrderByDescending(p => p.Id).ToList();
            return View(patients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (patient.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (!patient.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil formatinda file sechin");
                return View();
            }
            if (patient.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 1600kb ola biler");
                return View();
            }
            patient.Image = await patient.Photo.SaveImage(_env.WebRootPath, "images");
            await _db.AddAsync(patient);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Patient");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Patient patient = _db.Patients.Find(id);
            if (patient == null) return NotFound();
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {

            if (id == null) return NotFound();
            Patient patient = _db.Patients.Find(id);
            if (patient == null) return NotFound();
            Helpers.DeleteImg(_env.WebRootPath, "images", patient.Image);
            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Patient");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Patient patient = _db.Patients.Find(id);
            if (patient == null) return NotFound();
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Patient patient)
        {
            if (id == null) return NotFound();
            Patient dbPatient = _db.Patients.Find(id);
            if (patient == null) return NotFound();
            if (patient.Photo != null)
            {
                if (!patient.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil sechin");
                    return View();
                }
                if (patient.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb dan artiq ola bilmez");
                    return View();
                }
                Helpers.DeleteImg(_env.WebRootPath, "images", dbPatient.Image);
                dbPatient.Image = await patient.Photo.SaveImage(_env.WebRootPath, "images");
                dbPatient.Description = patient.Description;
                dbPatient.FullName = patient.FullName;
                dbPatient.Profession = patient.Profession;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Patient");
            }
            dbPatient.Description = patient.Description;
            dbPatient.FullName = patient.FullName;
            dbPatient.Profession = patient.Profession;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Patient");
        }
    }
}