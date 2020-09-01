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
                    Text = model.CommentText,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.SocMediaId == _userId)
                        .Select(
                            e =>
                                new Comment
                                {
                                    CommentPost = e.Post
                                }
                        );
                return query.ToArray();
            }
        }


    }
}
