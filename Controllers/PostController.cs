using System;
using System.Collections.Generic;
using System.Linq;
using Gerardo_BLOG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gerardo_BLOG.Controllers
{
    ///
    ///Summary : Controller Post, validate unique title View:@Post/
    ///
    public class PostController : Controller
    {
        public IActionResult Index()
        {           
            return View("Index", _context.Posts);
        }
        //Verify if context has data to sent the view
        public IActionResult Create()
        {
            GetCategory();
            return View();
        }

        private void GetCategory()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst = _context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Title }).ToList();
            ViewBag.ListCategories = lst;
        }
        ///Use redirect to action and viewbag to specify a validation messages in views
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                GetCategory();
                ViewBag.Fecha = DateTime.Now;
                if(_context.Posts
                .Any(ac=>ac.Title.Equals(post.Title) ))
                {
                    ModelState.AddModelError("Title", "Title has been exist already");//Val unique ID
                     return View();
                }
                ///VALIDATE POST DATE BEFORE THE REAL DATE 
                if(post.publicationDate > DateTime.Now.Date)
                {
                    ModelState.AddModelError("publicationDate", "The date must be before or equal to actual date");
                    return View();          
                }               
                _context.Posts.Add(post);
                _context.SaveChanges();                
                string msg = $"Post {post.Title} add successfully";
                return RedirectToAction("Index2","Home", new { Message = msg });
            }
            else
            {
                GetCategory();
                return View();
            }

        }

        public IActionResult Edit(int Id)
        {
            ViewBag.Fecha = DateTime.Now;
            var x = from posts in _context.Posts
                    where posts.Id == Id
                    select posts;
            GetCategory();
            return View(x.SingleOrDefault());

        }

        [HttpPost]
        public IActionResult Edit(Post post, int Id)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Fecha = DateTime.Now;
                GetCategory();
                if(_context.Posts
                .Any(ac=>ac.Title.Equals(post.Title) && ac.Id != Id ))
                {
                    ModelState.AddModelError("Title", "Title has been exist already");//Val unique ID
                    return View();
                }
                ///VALIDATE POST DATE BEFORE THE REAL DATE 
                if(post.publicationDate > DateTime.Now.Date)
                {
                    ModelState.AddModelError("publicationDate", "The date must be before or equal to actual date");
                    return View();          
                }                
                _context.Posts.Update(post);
                _context.SaveChanges();
                string msg =  $"Post {post.Title} edit successfully";
                return RedirectToAction("Index2","Home", new { Message = msg });
            }
            else
            {
                GetCategory();
                return View();
            }

        }
       //DELETE
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Posts.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
              
            }
            return View("Index");
        }

        private BlogContext _context;
        public PostController(BlogContext context)
        {
            _context = context;
        }
    }
}