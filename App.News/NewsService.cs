using System;
using App.News.Repositories;
using App.News.Models;
using App.Configuration;
using App.News.Interfaces;
using System.Collections.Generic;

namespace App.News
{
    public class NewsManager: INewsManager,ITransientDependency
    {
        private readonly INewsRepository newsRepository; 
        public NewsManager(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }
        public void AddComment(int newsId, string owner, string text)
        {
            throw new NotImplementedException();
        }

        public string AddComment(CommentDTO comment)
        {
            var news = newsRepository.GetNewsById(comment.NewsId);
            if (news == null)
            {
                return "news not found";
            }
            news.Comments.Add(comment);
            return "ok";
        }


        public IEnumerable<CommentDTO> GetNewsComments(int newsId)
        {
            return newsRepository.GetNewsById(newsId).Comments;
        }
    }
}
