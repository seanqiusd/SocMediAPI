using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "At least 4 characters")]
        [MaxLength(100, ErrorMessage = "No more than 100 characters")]
        public string Title { get; set; }
        [MaxLength(8000)]
        public string Text { get; set; }
    }
}
