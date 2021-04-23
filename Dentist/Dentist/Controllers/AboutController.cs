using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            AboutVM about = new AboutVM
            {
                Patients = _db.Patients.Take(6).OrderByDescending(p => p.Id).ToList(),
                WellComing = _db.WellComings.FirstOrDefault(),
                Doctor = _db.Doctors.Where(d => d.Position.Trim().ToLower() == "Хирург-имплантолог, директор клиники").FirstOrDefault()
            };

            return View(about);
        }
    }
}