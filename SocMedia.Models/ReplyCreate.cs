using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class ReplyCreate : CommentCreate
    {
        public int CommentId { get; set; }
    }
}
