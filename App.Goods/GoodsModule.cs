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
                    new Product() {Id = 1, Name = "Банан", Cost = random.Next(10, 100)},
                    new Product() {Id = 2, Name = "Молоко", Cost = random.Next(10, 100)},
                    new Product() {Id = 3, Name = "Апельсин", Cost = random.Next(10, 100)},
                    new Product() {Id = 4, Name = "Цукор", Cost = random.Next(10, 100)},
                    new Product() {Id = 5, Name = "Кава", Cost = random.Next(10, 100)},
                    new Product() {Id = 6, Name = "Печиво", Cost = random.Next(10, 100)},
                    new Product() {Id = 7, Name = "Телефон", Cost = random.Next(10, 100)},
                    new Product() {Id = 8, Name = "Телевізор", Cost = random.Next(10, 100)},
                    new Product() {Id = 9, Name = "Вікно", Cost = random.Next(10, 100)}
                });

                context.Orders.AddRange(new[]
                {
                    new Order() {Id = 1, OrderProducts = new List<OrderProduct>(new []
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
                    })},
                    new Order() {Id = 2, OrderProducts = new List<OrderProduct>(new []
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
                    })},
                    new Order() {Id = 3, OrderProducts = new List<OrderProduct>(new []
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
                    })}
                });

                context.SaveChanges();

                
            }
        }
    }
}
