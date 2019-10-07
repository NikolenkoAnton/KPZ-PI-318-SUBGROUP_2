using System.Collections.Generic;
using App.Configuration;
using App.Goods.Interfaces;
using App.Goods.Models;
using App.Goods.Repositories;

namespace App.Goods.Services
{
    public class ProductsManager : IProductsManager, ITransientDependency
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductsManager(IRepository<Product> productsRepository) => _productsRepository = productsRepository;

        public IEnumerable<Product> GetAllGoods() => _productsRepository.GetAll();
    }
}
