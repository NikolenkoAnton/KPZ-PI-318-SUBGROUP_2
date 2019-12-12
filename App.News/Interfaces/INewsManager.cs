using System;
using System.Collections.Generic;
using System.Text;
using App.News.Models;

namespace App.News.Interfaces
{
    public interface INewsManager
    {
        void AddComment(Comment comment);
        IEnumerable<Comment> GetNewsComments(int newsId);
        IEnumerable<Models.NewsDto> GetAllNews();
    }
}
