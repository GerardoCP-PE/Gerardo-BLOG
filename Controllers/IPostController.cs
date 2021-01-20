using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Gerardo_BLOG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gerardo_BLOG.Controllers
{
    ///
    ///Summary : Interface to REST API Posts
    ///
[Route("api/Post")]
    [ApiController]
    public class IPostController : ControllerBase
    {
        private readonly BlogContext _context;

        public IPostController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost()
        {
            var l1 = await _context.Posts.ToListAsync();

            if (l1 == null)
            {
                return NotFound();
            }
            return l1;
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var l1 = await _context.Posts.FindAsync(id);

            if (l1 == null)
            {
                return NotFound();
            }

            return l1;
        }

    }
    
}