using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriceController : Controller
    {
        private readonly AppDbContext _db;
        public PriceController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Price> prices = _db.Prices.Include(p => p.PriceDetails).OrderByDescending(p => p.Id).ToList();
            return View(prices);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Price price)
        {
            if (price == null) return NotFound();
            Price price1 = new Price()
            {
                PriceTitle = price.PriceTitle
            };
            if (price1 == null) return NotFound();
            await _db.Prices.AddAsync(price1);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Price");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Price price = _db.Prices.Find(id);
            if (price == null) return NotFound();
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Price price)
        {
            if (id == null) return NotFound();
            Price price1 = _db.Prices.Find(id);
            if (price1 == null) return NotFound();
            price1.PriceTitle = price.PriceTitle;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Price");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Price price = _db.Prices.Find(id);
            if (price == null) return NotFound();
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if(id == null) return NotFound();
            Price price = _db.Prices.Find(id);
            if (price == null) return NotFound();
            _db.Prices.Remove(price);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Price");
        }
    }
}