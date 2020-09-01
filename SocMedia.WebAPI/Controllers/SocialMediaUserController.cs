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
    public class SocialMediaUserController : ApiController
    {
        private SocMediaUserService CreateSocMediaUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userEmail = User.Identity.GetUserName();
            var socMediaUserService = new SocMediaUserService(userId, userEmail);
            return socMediaUserService;
        }

        [HttpPost]
        public IHttpActionResult CreateUser(SocMediaUserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSocMediaUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok("Account Created.");
        }
    }
}
