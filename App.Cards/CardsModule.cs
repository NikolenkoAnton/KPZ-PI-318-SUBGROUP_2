﻿using App.Configuration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using App.Cards.Models;
using App.Cards.Database;

namespace App.Cards
{
    public class CardsModule : IModule
    {
          public void Initialize(IWindsorContainer container)
        {

            RegisterDbContext(container);
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<AppCardsDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<AppCardsDbContext>();
                builder.UseInMemoryDatabase("ExampleDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<AppCardsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<AppCardsDbContext>())
            {
                context.Cards.AddRange(new[]
                {
                    new Card { Id =1, IsBlocked = false, Limit = 1000 },
                    new Card { Id =3, IsBlocked = true, Limit = 2000 },
                    new Card { Id =2, IsBlocked = false, Limit = 3000 }
                }); ;

                context.SaveChanges();
            }
        }
    }
}
