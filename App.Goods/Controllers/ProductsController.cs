using System.Collections.Generic;
using App.Goods.Common;
using App.Goods.DTOs;
using App.Goods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Goods.Controllers
{
    [Route("api/goods/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsManager _productsManager;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsManager productsManager, ILogger<ProductsController> logger)
        {
            _productsManager = productsManager;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            _logger.LogInformation("Call GetAllProducts method");

            return _productsManager.GetAllProducts();
        }
    }
}
