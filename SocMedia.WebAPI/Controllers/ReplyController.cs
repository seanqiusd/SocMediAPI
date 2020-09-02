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
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

        [HttpPost]
        public IHttpActionResult PostReplyToComment(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok("Reply added");
        }

        [HttpGet]
        public IHttpActionResult GetReplyById(int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }
    }
}
