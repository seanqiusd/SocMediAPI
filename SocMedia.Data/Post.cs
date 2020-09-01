using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Data
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        //[ForeignKey(nameof(User))]
        //public Guid SocMediaUser { get; set; }
        //public virtual SocMediaUser User { get; set; }
    }
}
