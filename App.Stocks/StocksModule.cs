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
        public void InitCompanies(StocksDBContext context)
        {
            var companies = new Company[9];

            for (int i = 0; i < companies.Length; i++)
            {


                var comp = new Company
                {
                    Id = i + 1,
                    Name = companiesName[i],
                    Description = "BlaBla",
                    IsOpenStocks = i % 2 == 0
                };

                context.Add(comp);
                context.SaveChanges();


                GenerateStocks(i + 1, context);
            }


        }
        private void GenerateStocks(int companyId, StocksDBContext context)
        {
            Stock[] stocks = new Stock[7];

            for (int i = 0; i < 7; i++)
            {
                var isEven = i % 2 == 1;
                stocks[i] = new Stock
                {
                    CompanyId = companyId,
                    Date = DateTime.Now.AddDays(i * -1),
                    Cost = new Random().Next(200 * i, 400 * i) + 470 * (i + 1)
                };
            }

            context.Stocks.AddRange(stocks);
            context.SaveChanges();
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
                InitCompanies(context);

                context.SaveChanges();
            }
        }
    }
}
