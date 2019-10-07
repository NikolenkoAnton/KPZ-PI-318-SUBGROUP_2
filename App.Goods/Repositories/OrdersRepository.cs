using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Interfaces;
using App.Goods.Models;

namespace App.Goods.Repositories
{
    public class OrdersRepository : IRepository<Order>, ISingletoneDependency
    {
        private static IEnumerable<Order> _orders;
        private static IRepository<Product> _productRepository;

        public OrdersRepository(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _orders = OrderInitializer.Initialize();
        }

        public void Add(Order item)
        {
            _orders = _orders.Append(item);
        }

        public Order Get(int id) => _orders.FirstOrDefault(pr => pr.Id == id);

        public IEnumerable<Order> GetAll() => _orders;

        private static class OrderInitializer
        {
            public static IEnumerable<Order> Initialize()
            {
                var products = _productRepository.GetAll();
                var orders = new Order[3];
                var random = new Random();

                for (int i = 0; i < orders.Length; i++)
                {
                    orders[i] = new Order()
                    {
                        Id = i + 1,
                        Products = products.TakeLast(random.Next(1, products.Count())).ToArray()
                    };
                }

                return orders;
            }
        }

    }
}
