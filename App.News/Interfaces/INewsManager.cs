using System;
using System.Collections.Generic;
using System.Text;
using App.News.Models;

namespace App.News.Interfaces
{
    public interface INewsManager
    {
        string AddComment(CommentDTO comment);
        IEnumerable<CommentDTO> GetNewsComments(int newsId);
    }
}
