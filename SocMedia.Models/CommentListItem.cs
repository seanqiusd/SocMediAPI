using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class CommentListItem
    {
        [Display(Name = "Post Id")]
        public int PostId { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}
