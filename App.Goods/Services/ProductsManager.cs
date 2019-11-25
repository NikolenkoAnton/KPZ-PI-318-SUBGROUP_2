using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.DTOs;
using App.Goods.Models;
using App.Goods.Repositories;
using Microsoft.Extensions.Logging;

namespace App.Goods.Services
{
    public class ProductsManager : IProductsManager, ITransientDependency
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly ILogger<ProductsManager> _logger;

        public ProductsManager(IRepository<Product> productsRepository, ILogger<ProductsManager> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            _logger.LogDebug("Call GetAllProducts method");

            return _productsRepository.GetAll().Select(p => new ProductDto(p));
        }
    }
}
