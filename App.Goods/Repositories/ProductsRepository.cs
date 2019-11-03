using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.Models;

namespace App.Goods.Repositories
{
    public class ProductsRepository : IRepository<Product>, ISingletoneDependency
    {
        private static IEnumerable<Product> _products;
        static ProductsRepository()
        {
            _products = ProductInitializer.Initialize();
        }

        public Product Get(int id) => _products.FirstOrDefault(pr => pr.Id == id);

        public IEnumerable<Product> GetAll() => _products;

        private static class ProductInitializer
        {
            private static readonly string[] ProductNames =
                {"Банан", "Молоко", "Апельсин", "Цукор", "Кава", "Печиво", "Телефон", "Телевізор", "Вікно"};
            
            public static IEnumerable<Product> Initialize()
            {
                var products = new Product[ProductNames.Length];
                var random = new Random();

                for (int i = 0; i < ProductNames.Length; i++)
                {
                    products[i] = new Product()
                    {
                        Id = i + 1,
                        Name = ProductNames[i],
                        Cost = random.Next(10, 100)
                    };
                }

                return products;
            }
        }
    }
}
