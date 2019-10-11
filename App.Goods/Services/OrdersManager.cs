using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.Models;

namespace App.Goods.Services
{
    public class OrdersManager : IOrdersManager, ITransientDependency
    {
        private readonly IAddOnRepository<Order> _ordersRepository;
        private readonly IRepository<Product> _productRepository;

        public OrdersManager(IAddOnRepository<Order> ordersRepository, IRepository<Product> productRepository)
        {
            _ordersRepository = ordersRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<Order> GetAllOrders() => _ordersRepository.GetAll();

        public Order MakeOrder(IEnumerable<int> products)
        {
            var orderedProducts = _productRepository.GetAll().Where(prod => products.Contains(prod.Id)).ToArray();
            
            if (!orderedProducts.Any())
            {
                throw new Exception("Product list is empty");
            }
            
            var lastOrder = GetAllOrders().LastOrDefault();
            int lastId = lastOrder?.Id ?? 0;

            var newOrder = new Order
            {
                Id = lastId + 1,
                Products = orderedProducts
            };

            _ordersRepository.Add(newOrder);

            return newOrder;
        }
    }
}
