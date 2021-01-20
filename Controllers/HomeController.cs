using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gerardo_BLOG.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gerardo_BLOG.Controllers
{
    public class HomeController : Controller
    {
       ///
        ///Summary : Home controller, Here use a dynamic controller to show category and post in one view
        /// 
        ///

        public IActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.VCategories =  (_context.Categories.Count() == 0) ? null :_context.Categories ;
            dy.VPosts = (_context.Posts.Count() == 0) ? null :_context.Posts ;
            GetCategory();
            return View(dy);  
        }

        private void GetCategory()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst = _context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Title }).ToList();
            ViewBag.ListCategories = lst;
        }
        public IActionResult Index2(string Message,int IsError = 0)
        {
            dynamic dy = new ExpandoObject();
            dy.VCategories =  (_context.Categories.Count() == 0) ? null :_context.Categories ;
            dy.VPosts = (_context.Posts.Count() == 0) ? null :_context.Posts ;
            GetCategory();
            ViewBag.Msg = Message;
            ViewBag.IsError = IsError;
            return View("Index",dy);  
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        private BlogContext _context;
        public HomeController(BlogContext context)
        {
            _context = context;
        }
    }
}
