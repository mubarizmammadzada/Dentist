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
    public class TreatmentController : Controller
    {
        private readonly AppDbContext _db;
        public TreatmentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Treatment> treatments = _db.Treatments.Include(t=>t.Portfolios).ToList();
            return View(treatments);
        }
        [Route("Treatment/{slug}")]
        public IActionResult Detail(string slug)
        {
            if (slug == null) return NotFound();
            Treatment treatment = _db.Treatments.Include(t => t.Portfolios).FirstOrDefault(t => t.Slug.Trim().ToLower() == slug.Trim().ToLower());
            if (treatment == null) return NotFound();
            return View(treatment);
        }
    }
}