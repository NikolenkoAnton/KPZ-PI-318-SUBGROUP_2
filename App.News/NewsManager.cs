using System;
using App.News.Repositories;
using System.Linq;
using App.News.Exceptions;
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
                throw new EntityNotFoundException(typeof(NewsDTO)); 
            }
            news.Comments.ToList().Add(comment);
        }

        public IEnumerable<CommentDTO> GetNewsComments(int newsId)
        {
            var news = newsRepository.GetNewsById(newsId);
            if (news ==null)
            {
                throw new EntityNotFoundException(typeof(NewsDTO));
            }
            return news.Comments;
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return newsRepository.GetAllNews().ToList();
        }

    }
}
