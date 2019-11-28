using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using App.News.Exceptions;
using App.News.Models;
using App.Configuration;
using App.News.Interfaces;


namespace App.News
{
    public class NewsManager: INewsManager,ITransientDependency
    {
        private readonly INewsRepository newsRepository;
        private readonly ILogger<NewsManager> logger;
        public NewsManager(INewsRepository newsRepository,ILogger<NewsManager> logger)
        {
            this.newsRepository = newsRepository;
            this.logger = logger;
        }
       
        public void AddComment(Comment comment)
        {
            logger.LogInformation("AddComment method called");
            var news = newsRepository.GetById(comment.NewsId);
            if (news == null)
            {
                logger.LogError("Entity was not found");
                throw new EntityNotFoundException(typeof(Models.NewsDto)); 
            }
            news.Comments.ToList().Add(comment);
        }

        public IEnumerable<Comment> GetNewsComments(int newsId)
        {
            logger.LogInformation("GetNewsComments method called");
            var news = newsRepository.GetById(newsId);
            if (news ==null)
            {
                logger.LogError("Entity was not found");
                throw new EntityNotFoundException(typeof(Models.NewsDto));
            }
            return news.Comments;
        }

        public IEnumerable<Models.NewsDto> GetAllNews()
        {
            logger.LogInformation("GetAllNews Method called");
            return newsRepository.GetAll();
        }

    }
}
