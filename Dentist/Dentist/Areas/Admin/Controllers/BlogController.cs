using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BlogController : Controller
    {

        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public BlogController(AppDbContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _db.Blogs.OrderByDescending(b => b.Id).ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil sechin");
                return View();
            }
            if (blog.Photo.MaxLength(1600))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu 1600k-dan cox ola bilmez");
                return View();
            }
            blog.Image = await blog.Photo.SaveImage(_env.WebRootPath, "images");

            
            blog.Slug = SlugGenerator.SlugGenerator.GenerateSlug(blog.BlogName.Trim(), "-");
            blog.Date = DateTime.UtcNow.AddHours(2);
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Blog");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs.Find(id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Blog blog)
        {
            if (id == null) return NotFound();
            Blog dbBlog = _db.Blogs.Find(id);
            if (dbBlog == null) return NotFound();
            if (blog.Photo != null)
            {
                if (!blog.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil sechin");
                    return View();

                }
                if (blog.Photo.MaxLength(1600))
                {
                    ModelState.AddModelError("Photo", "Shekilin olcusu 1600kb-dan chox ola bilmez");
                    return View();
                }
                Helpers.DeleteImg(_env.WebRootPath, "images", dbBlog.Image);
                dbBlog.Image = await blog.Photo.SaveImage(_env.WebRootPath, "images");
                dbBlog.Author = blog.Author;
                dbBlog.BlogName = blog.BlogName;
                dbBlog.Description = blog.Description;
                dbBlog.Slug = SlugGenerator.SlugGenerator.GenerateSlug(blog.BlogName.Trim(), "-");
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Blog");

            }
            dbBlog.Author = blog.Author;
            dbBlog.BlogName = blog.BlogName;
            dbBlog.Description = blog.Description;
            dbBlog.Slug = SlugGenerator.SlugGenerator.GenerateSlug(blog.BlogName.Trim(), "-");
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Blog");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs.Find(id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs.Find(id);
            if (blog == null) return NotFound();
            Helpers.DeleteImg(_env.WebRootPath, "images", blog.Image);
            _db.Blogs.Remove(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Blog");
        }
    }
}