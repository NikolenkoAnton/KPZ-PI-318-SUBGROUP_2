using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.Database;
using App.Goods.Models;

namespace App.Goods.Repositories
{
    public class EfProductsRepository : IRepository<Product>, IDisposable, ISingletoneDependency
    {
        private readonly GoodsDbContext _context;

        public EfProductsRepository(GoodsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
