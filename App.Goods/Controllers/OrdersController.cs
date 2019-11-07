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
        private readonly IValidateService _validateService;

        public OrdersController(IOrdersManager ordersManager, IValidateService validateService)
        {
            _ordersManager = ordersManager;
            _validateService = validateService;
        }

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersManager.GetAllOrders();
        }

        [HttpPost]
        public Order MakeOrder([FromBody] List<int> productsIds)
        {
            _validateService.ValidateIds(productsIds);

            return _ordersManager.MakeOrder(productsIds);
        }
    }
}
