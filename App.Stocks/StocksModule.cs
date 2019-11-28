using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Models;
using App.Stocks.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.Stocks
{
    public class StocksModule : IModule
    {
        readonly static string[] companiesName = new string[] { "Amazon", "McDonald’s", "GE", "Samsung", "Apple", "Huawei", "LG", "KFC", "Coca-Cola" };
        public static IEnumerable<Company> InitCompanies()
        {
            var companies = new Company[9];

            for (int i = 0; i < companies.Length; i++)
            {
                var stocks = GenerateStocks();

                var comp = new Company
                {
                    Id = i + 1,
                    Name = companiesName[i],
                    Stocks = stocks.ToArray(),
                    Description = "BlaBla",
                    IsOpenStocks = i % 2 == 0
                };

                companies[i] = comp;
            }

            return companies;
        }
        private static IEnumerable<Stock> GenerateStocks()
        {
            Stock[] stocks = new Stock[7];

            for (int i = 0; i < 7; i++)
            {
                stocks[i] = new Stock
                {
                    Date = DateTime.Now.AddDays(i * -1),
                    Cost = new Random().Next(200 * i, 400 * i) + 470 * (i + 1)
                };
            }
            return stocks;
        }
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);

        }
        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<StocksDBContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<StocksDBContext>();
                builder.UseInMemoryDatabase("StocksDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<StocksDBContext>().LifestyleTransient());

            InitializeDbContext(container);
        }
        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<StocksDBContext>())
            {
                context.Companies.AddRange(InitCompanies());

                context.SaveChanges();
            }
        }
    }
}
