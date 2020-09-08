using SocMedia.Data;
using SocMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    PostId = model.PostId,
                    Text = model.CommentText

                };

            using (var ctx = new ApplicationDbContext())
            {
                entity.Author = ctx.SocMediaUsers.Where(e => e.Id == _userId).First();
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 2;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments.ToList()
                    .Select(
                        e =>
                        {
                            var listItem = new CommentListItem
                            {
                                Id = e.Id,
                                PostId = e.PostId,
                                Text = e.Text
                            };
                            foreach (var reply in e.Replies)
                            {
                                var r = new ReplyDetail  //converting to ReplyDetail so we dont send reply dataclass outside of api
                                {
                                    Text = reply.Text
                                };

                                listItem.Replies.Add(r);
                            }
                            return listItem;
                        }).ToList();
                return query;
                //var entities = new List<CommentListItem>();
                //foreach (Comment c in ctx.Comments)
                //{
                //    //var test = c;
                //    var entity = new CommentListItem { Id = c.Id, PostId = c.PostId, Text = c.Text };
                //    entity.Replies = new List<Reply>(c.Replies);
                //    entities.Add(entity);
                //}
                //return entities;
            }
        }


    }
}
