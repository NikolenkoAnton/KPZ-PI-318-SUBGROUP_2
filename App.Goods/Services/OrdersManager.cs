using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.Models;
using Microsoft.Extensions.Logging;

namespace App.Goods.Services
{
    public class OrdersManager : IOrdersManager, ITransientDependency
    {
        private readonly IAddOnRepository<Order> _ordersRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly ILogger<OrdersManager> _logger;

        public OrdersManager(IAddOnRepository<Order> ordersRepository, IRepository<Product> productRepository, ILogger<OrdersManager> logger)
        {
            _ordersRepository = ordersRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            _logger.LogDebug("Call GetAllOrders method");

            return _ordersRepository.GetAll();
        }

        public Order MakeOrder(IEnumerable<int> products)
        {
            _logger.LogDebug("Call MakeOrder method");

            var orderedProducts = _productRepository.GetAll().Where(prod => products.Contains(prod.Id)).ToArray();

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
