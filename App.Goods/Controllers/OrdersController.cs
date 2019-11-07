﻿using System.Collections.Generic;
using App.Goods.Common;
using App.Goods.Filters;
using App.Goods.Models;
using App.Goods.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Goods.Controllers
{
    [Route("api/goods/orders")]
    [ApiController]
    [TypeFilter(typeof(GoodsExceptionFilter), Arguments = new object[] { nameof(OrdersController) })]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersManager _ordersManager;
        private readonly IValidateService _validateService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrdersManager ordersManager, IValidateService validateService, ILogger<OrdersController> logger)
        {
            _ordersManager = ordersManager;
            _validateService = validateService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            _logger.LogDebug("Call GetAllOrders method");

            return _ordersManager.GetAllOrders();
        }

        [HttpPost]
        public Order MakeOrder([FromBody] List<int> productsIds)
        {
            _logger.LogDebug("Call MakeOrder method");

            _validateService.ValidateIds(productsIds);

            return _ordersManager.MakeOrder(productsIds);
        }
    }
}
