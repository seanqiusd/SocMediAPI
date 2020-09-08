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
                Text = model.CommentText,
                CommentId = model.CommentId,
                PostId = model.PostId
            };

            using (var ctx = new ApplicationDbContext())
            {
                entity.Author = ctx.SocMediaUsers.Where(e => e.Id == _userId).First();
                ctx.Replys.Add(entity);
                return ctx.SaveChanges() == 2;
            }
        }

        //public ReplyDetail GetReplyById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Replys.Single(e => e.Id == id);

        //        return new ReplyDetail
        //        {
        //            Id = entity.Id,
        //            CommentId = entity.CommentId,
        //            PostId = entity.PostId,
        //            Text = entity.Text,
        //            Comment = entity.Comment
        //        };
        //    }
        //}
    }
}
