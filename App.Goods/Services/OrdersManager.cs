using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Interfaces;
using App.Goods.Models;

namespace App.Goods.Services
{
    public class OrdersManager : IOrdersManager, ITransientDependency
    {
        private readonly IRepository<Order> _ordersRepository;
        private readonly IRepository<Product> _productRepository;

        public OrdersManager(IRepository<Order> ordersRepository, IRepository<Product> productRepository)
        {
            _ordersRepository = ordersRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<Order> GetAllOrders() => _ordersRepository.GetAll();

        public void MakeOrder(int[] products)
        {
            var orderedProducts = _productRepository.GetAll().Where(prod => products.Contains(prod.Id)).ToArray();
            
            if (!orderedProducts.Any())
            {
                return;
            }
            
            var lastOrder = GetAllOrders().LastOrDefault();
            int lastId = lastOrder?.Id ?? 1;
            _ordersRepository.Add(new Order
            {
                Id = lastId + 1,
                Products = orderedProducts
            });
        }
    }
}
