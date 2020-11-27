using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Bio bio = _db.Bios.FirstOrDefault();
            return View(bio);
        }
    }
}