using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace App.News.Models
{
    public class NewsDto
    {
        
        public int Id { get; set; }
        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public NewsDto()
        {
            Comments = new List<Comment>();
        }

    }
}
