using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.Areas.Admin.ViewModels;
using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class PriceDetailController : Controller
    {
        private readonly AppDbContext _db;
        public PriceDetailController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<PriceDetail> priceDetails = _db.PriceDetails.OrderByDescending(p => p.Id).ToList();
            return View(priceDetails);
        }
        public IActionResult Create()
        {
            PriceVM priceVM = new PriceVM()
            {
                Prices = _db.Prices.ToList()
            };
            return View(priceVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PriceDetail priceDetail)
        {
            if (priceDetail == null) return NotFound();

            string servicePriceName = Request.Form["prices"];
            string booll = Request.Form["isexacts"];
            Price price = _db.Prices.FirstOrDefault(p => p.PriceTitle.ToLower().Trim() == servicePriceName.ToLower().Trim());
            PriceDetail priceDetail1 = new PriceDetail()
            {
                PriceDetaillName = priceDetail.PriceDetaillName,
                PriceDetailCost = priceDetail.PriceDetailCost,
                İsExactly = Boolean.Parse(booll.Trim().ToLower()),
                PriceId = price.Id
            };

            await _db.AddAsync(priceDetail1);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "PriceDetail");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            PriceVM priceVM = new PriceVM()
            {
                PriceDetail = _db.PriceDetails.Find(id),
                Prices = _db.Prices.ToList()
            };
            if (priceVM == null) return NotFound();
            return View(priceVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, PriceVM priceVM)
        {
            if (id == null) return NotFound();
            PriceDetail priceDetail = _db.PriceDetails.Find(id);
            if (priceDetail == null) return NotFound();
            string servicePriceName = Request.Form["prices"];
            string booll = Request.Form["isexacts"];
            Price price = _db.Prices.FirstOrDefault(p => p.PriceTitle.ToLower().Trim() == servicePriceName.ToLower().Trim());

            priceDetail.PriceDetaillName = priceVM.PriceDetail.PriceDetaillName;
            priceDetail.PriceDetailCost = priceVM.PriceDetail.PriceDetailCost;
            priceDetail.İsExactly = Boolean.Parse(booll.Trim().ToLower());
            priceDetail.PriceId = price.Id;
           
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "PriceDetail");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            PriceDetail priceDetail = _db.PriceDetails.Find(id);
            if (priceDetail == null) return NotFound();
            return View(priceDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            PriceDetail priceDetail = _db.PriceDetails.Find(id);
            if (priceDetail == null) return NotFound();
            _db.PriceDetails.Remove(priceDetail);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "PriceDetail");
        }
    }
}