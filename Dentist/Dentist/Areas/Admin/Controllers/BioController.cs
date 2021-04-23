using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin")]
    public class BioController : Controller
    {
        private readonly AppDbContext _db;
        public BioController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Bio bio = _db.Bios.FirstOrDefault();
            return View(bio);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Bio bio = _db.Bios.Find(id);
            if (bio == null) return NotFound();
            return View(bio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Bio bio)
        {

            if (id == null) return NotFound();
            Bio dbBio = _db.Bios.Find(id);
            if (bio == null) return NotFound();
            dbBio.Address = bio.Address;
            dbBio.Email = bio.Email;
            dbBio.Facebook = bio.Facebook;
            dbBio.Instagram = bio.Instagram;
            dbBio.PhoneNumber = bio.PhoneNumber;
            dbBio.Twitter = bio.Twitter;
            dbBio.WeekDaysOpenHour = bio.WeekDaysOpenHour;
            dbBio.WeekdayCloseHour = bio.WeekdayCloseHour;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Bio");
        }
    }
}