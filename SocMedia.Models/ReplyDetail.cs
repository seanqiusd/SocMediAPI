using SocMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class ReplyDetail : CommentListItem
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
