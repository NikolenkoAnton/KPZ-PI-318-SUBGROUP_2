using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.DTOs;
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

        public IEnumerable<OrderDto> GetAllOrders()
        {
            _logger.LogDebug("Call GetAllOrders method");

            return _ordersRepository.GetAll().Select(o => new OrderDto(o));
        }

        public OrderDto MakeOrder(IEnumerable<int> products)
        {
            _logger.LogDebug("Call MakeOrder method");

            var orderedProducts = _productRepository.GetAll().Where(prod => products.Contains(prod.Id)).ToArray();

            var lastOrder = GetAllOrders().LastOrDefault();
            int id = (lastOrder?.Id ?? 0) + 1;

            var ordersProducts = orderedProducts.Select(product => new OrderProduct {OrderId = id, ProductId = product.Id}).ToList();

            var newOrder = new Order
            {
                Id = id,
                OrderProducts = ordersProducts
            };

            _ordersRepository.Add(newOrder);

            return new OrderDto(_ordersRepository.Get(id));
        }
    }
}
