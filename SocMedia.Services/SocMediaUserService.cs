using SocMedia.Data;
using SocMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Services
{
    public class SocMediaUserService
    {
        private readonly Guid _userId;
        private readonly string _email;

        public SocMediaUserService(Guid userId, string email)
        {
            _userId = userId;
            _email = email;
        }

        public bool CreateUser(SocMediaUserCreate model)
        {            
            var entity =
                new SocMediaUser()
                {
                    Id = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = _email
                };

            using (var ctx = new ApplicationDbContext())
            {
                foreach (SocMediaUser s in ctx.SocMediaUsers)
                    if (s.Id == entity.Id)
                        return false;

                ctx.SocMediaUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
