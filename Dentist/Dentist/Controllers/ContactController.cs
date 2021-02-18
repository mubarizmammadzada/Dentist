using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Dentist.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;

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
            //Bio bio = _db.Bios.FirstOrDefault();
            ContactVM bio = new ContactVM()
            {
                Bio=_db.Bios.FirstOrDefault()
            };
            return View(bio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> SendMessage(Message message)
        {
            if (message == null)
            {
                ModelState.AddModelError("", "Mesaji doldurun");
                return View();
            }
            Message message1 = new Message()
            {
                Name = message.Name,
                Email = message.Email,
                Subject = message.Subject,
                Messagge = message.Messagge,
                PhoneNumber=message.PhoneNumber
            };
            await _db.Messages.AddAsync(message1);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Contact");
        }
    }
}