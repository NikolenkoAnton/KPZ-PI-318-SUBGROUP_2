using System;
using System.Collections.Generic;
using App.News.Database;
using App.News.Interfaces;
using App.News.Models;
using System.Linq;
using App.Configuration;

namespace App.News.Repositories
{
    public class NewsRepository : ITransientDependency, INewsRepository
    {

        protected readonly AppDbContext context;
        public NewsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(NewsDto obj)
        {
            context.News.Add(obj);
            Save();
        }

        public void Delete(int? id)
        {
            var obj = GetById(id);
            context.News.Remove(obj);
            Save();
        }

        public IQueryable<NewsDto> GetAll()
        {
            return context.News;
        }

        public NewsDto GetById(int? id)
        {
            return context.News
                          .Find(id);
        }
       
        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }



}
