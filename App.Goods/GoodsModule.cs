using System;
using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Database;
using App.Goods.Models;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.Goods
{
    public class GoodsModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<GoodsDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<GoodsDbContext>();
                builder.UseInMemoryDatabase("GoodsDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<GoodsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<GoodsDbContext>())
            {
                var random = new Random();

                context.Products.AddRange(new[]
                {
                    new Product() {Name = "Банан", Cost = random.Next(10, 100)},
                    new Product() {Name = "Молоко", Cost = random.Next(10, 100)},
                    new Product() {Name = "Апельсин", Cost = random.Next(10, 100)},
                    new Product() {Name = "Цукор", Cost = random.Next(10, 100)},
                    new Product() {Name = "Кава", Cost = random.Next(10, 100)},
                    new Product() {Name = "Печиво", Cost = random.Next(10, 100)},
                    new Product() {Name = "Телефон", Cost = random.Next(10, 100)},
                    new Product() {Name = "Телевізор", Cost = random.Next(10, 100)},
                    new Product() {Name = "Вікно", Cost = random.Next(10, 100)}
                });

                context.Orders.AddRange(new[]
                {
                    new Order(),
                    new Order(),
                    new Order()
                });

                context.SaveChanges();

                context.Orders.Find(1).OrderProducts = new List<OrderProduct>(new[]
                {
                    new OrderProduct
                    {
                        OrderId = 1,
                        ProductId = 5
                    },
                    new OrderProduct
                    {
                        OrderId = 1,
                        ProductId = 3
                    },
                    new OrderProduct
                    {
                        OrderId = 1,
                        ProductId = 4
                    }
                });

                context.Orders.Find(2).OrderProducts = new List<OrderProduct>(new[]
                {
                    new OrderProduct
                    {
                        OrderId = 2,
                        ProductId = 6
                    },
                    new OrderProduct
                    {
                        OrderId = 2,
                        ProductId = 2
                    }
                });

                context.Orders.Find(3).OrderProducts = new List<OrderProduct>(new[]
                {
                    new OrderProduct
                    {
                        OrderId = 3,
                        ProductId = 1
                    },
                    new OrderProduct
                    {
                        OrderId = 3,
                        ProductId = 3
                    },
                    new OrderProduct
                    {
                        OrderId = 3,
                        ProductId = 9
                    }
                });

                context.SaveChanges();

            }
        }
    }
}
