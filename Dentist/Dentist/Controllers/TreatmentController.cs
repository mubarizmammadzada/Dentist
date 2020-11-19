using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly AppDbContext _db;
        public TreatmentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Salam = "Salam";
            List<Treatment> treatments = _db.Treatments.ToList();
            return View(treatments);
        }
    }
}