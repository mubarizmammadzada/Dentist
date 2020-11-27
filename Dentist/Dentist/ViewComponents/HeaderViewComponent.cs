using Dentist.DAL;
using Dentist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public HeaderViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bios = _db.Bios.FirstOrDefault();
            return View(await Task.FromResult(bios));
        }
    }
}
