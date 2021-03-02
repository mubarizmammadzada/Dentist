using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.Areas.Admin.ViewModels;
using Dentist.DAL;
using Dentist.Extentions;
using Dentist.Helper;
using Dentist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
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
            ServiceVM serviceVM = new ServiceVM
            {
                Treatments=_db.Treatments.ToList()
            };
            return View(serviceVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceVM serviceVM)
        {
            if (!serviceVM.Portfolio.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (serviceVM.Portfolio.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu 1600kb-dan chox ola bilmez");
                return View();
            }
            serviceVM.Portfolio.Image = await serviceVM.Portfolio.Photo.SaveImage(_env.WebRootPath, "images");
            string a = Request.Form["services"];
            Treatment treatment = _db.Treatments.FirstOrDefault(t => t.TreatmentName.ToLower().Trim() == a.Trim().ToLower());
            serviceVM.Portfolio.TreatmentId = treatment.Id;
            await _db.Portfolios.AddAsync(serviceVM.Portfolio);
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