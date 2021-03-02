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
    public class PriceController : Controller
    {
        private readonly AppDbContext _db;
        public PriceController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Price> prices = _db.Prices.Include(p => p.PriceDetails).ToList();
            return View(prices);
        }
    }
}