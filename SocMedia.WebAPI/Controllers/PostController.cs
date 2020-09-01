using SocMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SocMedia.WebAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Create
        [HttpPost]
        public async Task<IHttpActionResult> CreatePost(Post model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                _context.Posts.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
