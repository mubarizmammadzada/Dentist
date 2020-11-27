using Dentist.DAL;
using Dentist.Models;
using Dentist.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentist.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public FooterViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            BioVM bioVM = new BioVM
            {
                Bio= _db.Bios.FirstOrDefault(),
                Blogs=_db.Blogs.OrderByDescending(b=>b.Id).Take(2).ToList()
            };
            return View(await Task.FromResult(bioVM));
        }
    }
}
