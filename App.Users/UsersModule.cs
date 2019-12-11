using App.Configuration;
using App.Models.Users;
using App.Users.Database;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.Users
{
    public class UsersModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);
        }

        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<UsersDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<UsersDbContext>();
                builder.UseInMemoryDatabase("UsersDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<UsersDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<UsersDbContext>())
            {
                context.SimpleValues.AddRange(new[]
                {
                    new User { Id = 1, IsAvailable = true, Login = "Chuck01", Name = "Chuck Norris", Password = "qwerty" },
                    new User { Id = 2, IsAvailable = false, Login = "john_qw", Name = "John Smith", Password = "password" },
                    new User { Id = 3, IsAvailable = true, Login = "patRick", Name = "Christopher Robinson", Password = "veryHARDpass" },
                    new User { Id = 4, IsAvailable = false, Login = "GeRaLT", Name = "Thomas Nelson", Password = "12345" }
                });

                context.SaveChanges();
            }
        }
    }
}
