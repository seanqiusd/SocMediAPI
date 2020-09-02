using SocMedia.Data;
using SocMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                PostId = model.PostId,
                Text = model.CommentText,
                CommentId = model.CommentId
            };

            using (var ctx = new ApplicationDbContext())
            {
                entity.Author = ctx.SocMediaUsers.Where(e => e.Id == _userId).First();
                ctx.Replys.Add(entity);
                return ctx.SaveChanges() == 2;
            }
        }
    }
}
