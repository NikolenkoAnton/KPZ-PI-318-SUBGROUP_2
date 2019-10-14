using System;
using System.Collections.Generic;
using System.Text;
using App.News.Models;

namespace App.News.Interfaces
{
    public interface INewsRepository
    {
        IEnumerable<NewsDTO> GetAllNews();
        NewsDTO GetNewsById(int id);
        IEnumerable<CommentDTO> GetNewsComments(int id);
    }
}
