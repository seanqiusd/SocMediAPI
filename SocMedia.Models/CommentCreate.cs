using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [MaxLength(6000)]
        public string CommentText { get; set; }

        //public int CommentId { get; set; } using this to create new branch don't do anything



    }
}
