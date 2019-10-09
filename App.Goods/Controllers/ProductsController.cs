using System.Collections.Generic;
using App.Goods.Common;
using App.Goods.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Goods.Controllers
{
    [Route("api/goods/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsManager _productsManager;

        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _productsManager.GetAllProducts();
        }
    }
}
