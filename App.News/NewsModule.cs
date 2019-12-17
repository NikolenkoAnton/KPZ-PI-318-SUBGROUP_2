using App.Configuration;
using App.News.Database;
using App.News.Interfaces;
using App.News.Models;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.News
{
    public class NewsModule : IModule
    {
      
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<AppDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<AppDbContext>();
                builder.UseInMemoryDatabase("NewsDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<AppDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

          
        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<AppDbContext>())
            {
                // add values to the context (without saving)
                var news = new NewsDto { PhotoUrl = "url", Text = "News", Title = "Title" };
                var comment = new Comment { Owner = "Someone", Text = "Comment", NewsId = 0, News = news };
                context.News.Add(news);
                context.Comments.Add(comment);

                // save changes in the context
                context.SaveChanges();
            }
        }
    }
}