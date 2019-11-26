using System;
using System.Collections.Generic;
using System.Text;

namespace App.News.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Text { get; set; }
        public int? NewsId { get; set; }
        public NewsDto News { get; set; }
    }
}
