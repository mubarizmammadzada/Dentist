using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}