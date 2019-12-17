using App.Accounts.Inerfaces;
using App.Accounts.Localization;
using App.Accounts.Models;
using App.Accounts.Services;
using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.Accounts
{
    public class AccountsModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<IValidateServices>().ImplementedBy<ValidateServices>().LifestyleTransient());
            RegisterDbContext(container);
        }
        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<AccountsDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<AccountsDbContext>();
                builder.UseInMemoryDatabase("AccountDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<AccountsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }
        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<AccountsDbContext>())
            {
                context.Accounts.AddRange(new[]
                {
                      new Account(1, 34000, "Vasya", "Pupkin"),
                      new Account(2, 17000, "Petro", "Poroshenko"),
                      new Account(3, 7000, "Maria", "Ivanovna"),
                      new Account(4, -15000, "Anna", "Ivanovna")
            });
                context.SaveChanges();
            }
        }
    }
}
