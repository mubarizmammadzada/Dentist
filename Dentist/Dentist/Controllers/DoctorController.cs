using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppDbContext _db;
        public DoctorController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Doctor> doctors = _db.Doctors.Take(8).ToList();
            return View(doctors);
        }
        [Route("doctor/{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            if (slug == null) return NotFound();
            Doctor doctor =await _db.Doctors.Include(d=>d.Certificates).FirstOrDefaultAsync(d=>d.Slug==slug);
            if (doctor.Certificates.ToList().Count > 0)
            {
                if (doctor == null) return NotFound();
                return View(doctor);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
           
        }
    }
}