using System;
using System.Collections.Generic;
using System.Text;
using App.News.Interfaces;
using App.News.Models;
using System.Linq;
using App.Configuration;

namespace App.News.Repositories
{
    public class InMemoryNewsRepository: INewsRepository, ITransientDependency
    {

        public static List<NewsDTO> News =Initializer.Init();
        public IEnumerable<NewsDTO> GetAllNews()
        {
            return News;
        }

        public NewsDTO GetNewsById(int id)
        {
            return (from t in News where t.id == id select t).FirstOrDefault();
        }

        class Initializer
        {
            public static List<NewsDTO> Init()
            {
                var News = new List<NewsDTO>();
                var Comments = new List<CommentDTO> { new CommentDTO() { Owner = "Someone", Text = "Comment" } };
               // var news = new NewsDTO() { id = 1, PhotoUrl = "url", Text = "News", Title = "Title",Comments = Comments};

               // News.Add(news);

                return News;
            }
            
        }
    }

   
}
