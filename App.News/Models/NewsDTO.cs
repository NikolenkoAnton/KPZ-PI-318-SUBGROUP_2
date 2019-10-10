using System;
using System.Collections.Generic;
using System.Text;

namespace App.News.Models
{
    public class NewsDTO
    {
        public int id;
        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public List<CommentDTO> Comments { get; set; }

    }
}
