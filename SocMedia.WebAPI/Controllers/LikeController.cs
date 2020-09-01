using Microsoft.AspNet.Identity;
using SocMedia.Models;
using SocMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocMedia.WebAPI.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var LikeService = new LikeService(userId);
            return LikeService;
        }
        [HttpPost]
        public IHttpActionResult PostLikebyPostId(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.CreateLike(like))
                return InternalServerError();

            return Ok();
        }
    }
}
