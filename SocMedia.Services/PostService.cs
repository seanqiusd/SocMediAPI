using SocMedia.Data;
using SocMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Services
{
    public class PostService
    {
        private readonly Guid _userID;
        public PostService(Guid userId)
        {
            _userID = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Title = model.Title,
                    Text = model.Text,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
