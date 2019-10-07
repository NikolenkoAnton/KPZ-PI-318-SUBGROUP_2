using System.Collections.Generic;
using System.Linq;
using App.Goods.Interfaces;
using App.Goods.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Goods.Controllers
{
    [Route("api/goods/[controller]")]
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
        public void MakeOrder([FromBody] int[] productsIds)
        {
            var validIds = _validateService.ValidateIds(productsIds).ToArray();
            _ordersManager.MakeOrder(validIds);
        }
    }
}
