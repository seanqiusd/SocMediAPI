using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Data
{
    public class Comment
    {
        
        [ForeignKey("SocMediaUser")]
        public Guid SocMediaId { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public SocMediaUser Author { get; set; }

        public virtual SocMediaUser SocMediaUser { get; set; }

        [ForeignKey("Post")]
        public Post CommentPost { get; set; }
        public virtual Post Post { get; set; }


    }
}