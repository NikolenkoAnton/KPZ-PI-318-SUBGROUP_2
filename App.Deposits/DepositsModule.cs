using App.Configuration;
using App.Deposits.DataBase;
using App.Deposits.Models;
using App.Deposits.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.Deposits
{
    public class DepositsModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<IAnotherService>().ImplementedBy<AnotherService>().LifestyleTransient());

            RegisterDbContext(container);
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<DepositsDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<DepositsDbContext>();

                builder.UseInMemoryDatabase("DepositsDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<DepositsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            using(var context = container.Resolve<DepositsDbContext>())
            {
                context.Deposits.AddRange(new[]
                {
                    new Deposit { Id = 1, Name = "Defoult", InterestRate = 0.15m },
                    new Deposit { Id = 2, Name = "Students", InterestRate = 0.20m },
                    new Deposit { Id = 3, Name = "Retirement", InterestRate = 0.25m },
                });

                context.SaveChanges();
            }
        }
    }
}
