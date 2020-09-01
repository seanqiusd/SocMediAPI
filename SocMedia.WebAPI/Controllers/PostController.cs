using Microsoft.AspNet.Identity;
using SocMedia.Data;
using SocMedia.Models;
using SocMedia.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SocMedia.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        //private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Create
        //[HttpPost]
        //public async Task<IHttpActionResult> CreatePost(Post model)
        //{
        //    if (model is null)
        //    {
        //        return BadRequest("Your request body cannot be empty");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _context.Posts.Add(model);
        //        await _context.SaveChangesAsync();

        //        return Ok();
        //    }
        //    return BadRequest(ModelState);
        //}

        //// Get
        //[HttpGet]
        //public async Task<IHttpActionResult> GetAll()
        //{
        //    List<Post> posts = await _context.Posts.ToListAsync();
        //    return Ok(posts);
        //}

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }


        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }
    }
}
