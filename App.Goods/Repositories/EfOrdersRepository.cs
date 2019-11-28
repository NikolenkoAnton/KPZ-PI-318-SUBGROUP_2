using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.Database;
using App.Goods.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Goods.Repositories
{
    public class EfOrdersRepository : IAddOnRepository<Order>, IDisposable, ITransientDependency
    {
        private readonly GoodsDbContext _context;

        public EfOrdersRepository(GoodsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).ToList();
        }

        public Order Get(int id)
        {
            return _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
