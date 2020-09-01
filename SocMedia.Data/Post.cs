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

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual SocMediaUser User { get; set; }
        [Required]
        public SocMediaUser Author { get; set; }
        //public virtual List<Like> Likes { get; set; } = new List<Like>();
    }
}