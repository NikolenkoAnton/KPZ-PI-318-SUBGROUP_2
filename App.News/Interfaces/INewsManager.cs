using System;
using System.Collections.Generic;
using System.Text;
using App.News.Models;

namespace App.News.Interfaces
{
    public interface INewsManager
    {
        void AddComment(CommentDTO comment);
        IEnumerable<CommentDTO> GetNewsComments(int newsId);
        IEnumerable<NewsDTO> GetAllNews();
    }
}
