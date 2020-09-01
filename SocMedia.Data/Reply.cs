using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Data
{
    public class Reply : Comment
    {
        public string ReplyComment
        {
            get
            {
                return $"{CommentPost}";
            }
        }
    }
}
