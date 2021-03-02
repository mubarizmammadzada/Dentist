using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dentist.Models;
using Dentist.DAL;
using Dentist.ViewModels;

namespace Dentist.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                WellComing = _db.WellComings.FirstOrDefault(),
                Doctor=_db.Doctors.Where(d=>d.Position== "генеральный директор и основатель").FirstOrDefault(),
                Treatments=_db.Treatments.Take(8).ToList(),
                Doctors=_db.Doctors.OrderBy(d=>d.Id).Take(4).ToList(),
                Patient=_db.Patients.OrderByDescending(p=>p.Id).Take(6).ToList(),
                Blogs=_db.Blogs.OrderByDescending(b=>b.Id).Take(3).ToList(),
                Portfolios=_db.Portfolios.OrderByDescending(p=>p.Id).Take(15).ToList(),
            };
            return View(homeVM);
        }

       
    }
}
