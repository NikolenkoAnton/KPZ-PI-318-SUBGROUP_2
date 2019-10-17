using System.Collections.Generic;
using App.Goods.Common;
using App.Goods.Models;
using App.Goods.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Goods.Controllers
{
    [Route("api/goods/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersManager _ordersManager;
        private readonly INormalizeService _normalizeService;

        public OrdersController(IOrdersManager ordersManager, INormalizeService normalizeService)
        {
            _ordersManager = ordersManager;
            _normalizeService = normalizeService;
        }

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersManager.GetAllOrders();
        }

        [HttpPost]
        public Order MakeOrder([FromBody] List<int> productsIds)
        {
            _normalizeService.CleanIds(productsIds);

            return _ordersManager.MakeOrder(productsIds);
        }
    }
}
