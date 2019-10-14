using System;
using App.News.Repositories;
using System.Linq;
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
       
        public string AddComment(CommentDTO comment)
        {
            var news = newsRepository.GetNewsById(comment.NewsId);
            if (news == null)
            {
                return "news not found";
            }
            news.Comments.ToList().Add(comment);
            return "ok";
        }

        public IEnumerable<CommentDTO> GetNewsComments(int newsId)
        {
            return newsRepository.GetNewsById(newsId).Comments;
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return newsRepository.GetAllNews().ToList();
        }

    }
}
