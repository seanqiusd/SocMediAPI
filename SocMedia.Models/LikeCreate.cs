﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocMedia.Models
{
    public class LikeCreate
    {
        [Required]
        public int PostId { get; set; }
    }
}
