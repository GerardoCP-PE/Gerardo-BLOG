using System;
using Microsoft.AspNetCore.Mvc;
using Gerardo_BLOG.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Gerardo_BLOG.Controllers
{
    ///
    ///Summary : Category controller, here validate the correct input to category table, validate unique title View:@Category/
    ///
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {           
            return View("Index", _context.Categories);
        }



        public IActionResult Create()
        {

            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                if(_context.Categories
                .Any(ac=>ac.Title.Equals(category.Title) ))
                {
                    ModelState.AddModelError("Title", "Title has been exist already");//Val unique ID
                     return View();
                }
                _context.Categories.Add(category);
                _context.SaveChanges();               
                string msg =  $"Category {category.Title} add successfully";
                return RedirectToAction("Index2","Home", new { Message = msg });
            }
            else
            {
                return View();
            }
        }
        ///EDIT
        public IActionResult Edit(int Id)
        {
            ViewBag.Fecha = DateTime.Now;
            var x = from cate in _context.Categories
                      where cate.Id == Id
                      select cate;
            return View(x.SingleOrDefault());

        } 
        ///Use redirect to action and viewbag to specify a validation messages in views
        [HttpPost]
        public IActionResult Edit(Category cate, int Id)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                if(_context.Categories
                .Any(ac=>ac.Title.Equals(cate.Title) && ac.Id != Id ))
                {
                    ModelState.AddModelError("Title", "Title has been exist already"); //Val unique ID
                     return View();
                }
                _context.Categories.Update(cate);
                _context.SaveChanges();
                string msg = $"Category {cate.Title} edit successfully";                 
                return RedirectToAction("Index2","Home", new { Message = msg });
                
            }
            else
            {
                return View(cate);
            }
        }
        //DELETE
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {

                if(_context.Posts
                .Any(ac=>ac.CategoryId.Equals(id) ))
                {
                    string msg = $"Cannot delete Category {model.Title}, it has posts";               
                    return RedirectToAction("Index2","Home", new { Message = msg , IsError = 1});
                }

                _context.Categories.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View("Index");
        }

        private BlogContext _context;
        public CategoryController(BlogContext context)
        {
            _context = context;
        }



    }
}