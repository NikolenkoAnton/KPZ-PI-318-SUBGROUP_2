using System;
using System.Collections.Generic;
using System.Text;

namespace App.News.Models
{
    public class CommentDTO
    {
        public int NewsId {get;set;}
        public string Owner { get; set; }
        public string Text { get; set; }
    }
}
