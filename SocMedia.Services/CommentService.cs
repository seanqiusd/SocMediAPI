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

        public CommentService (Guid userId)
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
                    .Comments
                    .Where(e => e.Author.Id == _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            PostId = e.PostId,
                            Text = e.Text,
                        }
                        );
                return query.ToArray();
            }
        }


    }
}
