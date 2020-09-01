using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class PostDetail
    {
        [Display(Name ="Post ID")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

    }
}
