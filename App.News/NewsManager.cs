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
       
        public void AddComment(CommentDTO comment)
        {
            var news = newsRepository.GetNewsById(comment.NewsId);
            if (news == null)
            {
                throw new NullReferenceException(); 
            }
            news.Comments.ToList().Add(comment);
        }

        public IEnumerable<CommentDTO> GetNewsComments(int newsId)
        {
            return newsRepository.GetNewsComments(newsId);
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return newsRepository.GetAllNews().ToList();
        }

    }
}
