using SocMedia.Data;
using SocMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Services
{
    class SocMediaUserService
    {
        private readonly Guid _userId;

        public SocMediaUserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(SocMediaUserCreate model)
        {
            var entity =
                new SocMediaUser()
                {
                    Id = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SocMediaUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
