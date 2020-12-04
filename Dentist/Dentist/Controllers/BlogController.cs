using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dentist.DAL;
using Dentist.Models;
using Dentist.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page)
        {
            ViewBag.Page = page;
            ViewBag.PageCount = Math.Ceiling((decimal)_db.Blogs.Count() / 6);
            if (page == null)
            {
                List<Blog> blogs = _db.Blogs.OrderByDescending(b => b.Id).ToList();
                return View(blogs);
            }
            else
            {
                List<Blog> blogs = _db.Blogs.Skip(((int)page-1)*6).OrderByDescending(b => b.Id).ToList();
                return View(blogs);
            }
           
        }
        [Route("blog/{slug}")]
        public IActionResult Detail(string slug)
        {
            if (string.IsNullOrEmpty(slug)) return NotFound(); 
            Blog blog = _db.Blogs.FirstOrDefault(b=>b.Slug==slug);
            if (blog == null) return NotFound();
            BlogVM blogVM = new BlogVM
            { 
                Blog = blog,
                Blogs=_db.Blogs.Take(3).OrderByDescending(b=>b.Id).ToList()
            };
            return View(blogVM);

        }
    }
}