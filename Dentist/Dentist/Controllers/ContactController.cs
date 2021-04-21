using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Dentist.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using MimeKit;

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
            
            ContactVM bio = new ContactVM()
            {

                Bio=_db.Bios.FirstOrDefault()
                
            };
            return View(bio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult SendMail(ContactVM messsage)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(messsage.Message.Email);
            mail.To.Add(new MailAddress("ckdentkamran@gmail.com"));
            mail.Subject = messsage.Message.Subject + "," + $"Telefon:{messsage.Message.PhoneNumber}" + "," + $"Mail:{messsage.Message.Email}";
            mail.Body = messsage.Message.Messsage;
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("ckdentmailsender@gmail.com", "mubu1905");
            smtp.Send(mail);
            return RedirectToAction(nameof(Index));
        }
        
    }
}