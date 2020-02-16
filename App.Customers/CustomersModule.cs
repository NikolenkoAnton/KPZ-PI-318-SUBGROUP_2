using System;
using System.Collections.Generic;
using App.Configuration;
using App.Customers.Models;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
namespace App.Customers
{
    public class CustomersModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<Customer>().ImplementedBy<Customer>().LifestyleTransient());
            RegisterDbContext(container);
        }

        IEnumerable<Customer> init()
        {
            Customer[] customers = new Customer[3]
            {
                    new Customer("Pochtalion", "Pechkin", 8495874957940),
                    new Customer("Gospodin", "Nikto", 49583458379475),
                    new Customer("Spat", "Hochu", 4283984239834)
            };
            return customers;
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<CustomersDBContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<CustomersDBContext>();
                
                builder.UseInMemoryDatabase("CustomersDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<CustomersDBContext>().LifestyleTransient());
            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            using(var context = container.Resolve<CustomersDBContext>())
            {
                context.Customers.AddRange(init());
                context.SaveChanges();
            }
        }
    }
}
