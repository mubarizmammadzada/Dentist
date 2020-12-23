using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Extentions;
using Dentist.Helper;
using Dentist.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public PortfolioController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Portfolio> portfolios = _db.Portfolios.OrderByDescending(p => p.Id).ToList();
            return View(portfolios);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            if (!portfolio.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (portfolio.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb-dan chox ola bilmez");
                return View();
            }
            portfolio.Image = await portfolio.Photo.SaveImage(_env.WebRootPath, "images");
            await _db.Portfolios.AddAsync(portfolio);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Portfolio");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Portfolio portfolio = _db.Portfolios.Find(id);
            if (portfolio == null) return NotFound();
            return View(portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Portfolio portfolio = _db.Portfolios.Find(id);
            if (portfolio == null) return NotFound();
            Helpers.DeleteImg(_env.WebRootPath, "images", portfolio.Image);
            _db.Portfolios.Remove(portfolio);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Portfolio");
        }
    }
}