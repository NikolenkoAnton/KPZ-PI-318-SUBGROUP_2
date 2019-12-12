using System;
using System.Collections.Generic;
using System.Text;
using App.News.Models;
using System.Linq;
namespace App.News.Interfaces
{
    public interface INewsRepository
    {
        void Add(NewsDto obj);
        void Delete(int? id);
        IQueryable<NewsDto> GetAll();
        NewsDto GetById(int? id);
        void Save();
    }
}
