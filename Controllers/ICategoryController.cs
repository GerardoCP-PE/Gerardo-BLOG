using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Gerardo_BLOG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace Gerardo_BLOG.Controllers
{
    ///
    ///Summary : Interface to REST API Category
    ///
    [Route("api/categories")]
    [ApiController]
    public class ICategoryController : ControllerBase
    {
        private readonly BlogContext _context;

        public ICategoryController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var l1 = await _context.Categories.ToListAsync();

            if (l1 == null)
            {
                return NotFound();
            }
            return l1;
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var l1 = await _context.Categories.FindAsync(id);

            if (l1 == null)
            {
                return NotFound();
            }

            return l1;
        }

        [HttpGet("{id}/posts")]
        public  ActionResult<IEnumerable<Post>> GetCategoryPosts(int id)
        {
            var d =  _context.Posts.Where(x => x.CategoryId == id).ToArray();
             if (d.Length == 0)
                  return NotFound();

            return d;
        }

    }

}