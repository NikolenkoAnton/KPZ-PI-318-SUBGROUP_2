using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.UserSupport.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace App.UserSupport
{
    public class UserSupportModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);
        }

        IEnumerable<Handling> InitHandlings()
        {
            Handling[] handlings = new Handling[5];
            Client[] clients = new Client[]{
                new Client("Nikita"),
                new Client("Alina"),
                new Client("Masha"),
                new Client("Lana"),
                new Client("Anton")};

            for(int i = 0;i < 5; i++)
            {
                handlings[i] = new Handling(clients[i], "Some times i have troubles", i, i);
            }

            handlings[0].status = true;
            handlings[1].WriteAnswer("What happend?", 6);
            handlings[2].WriteAnswer("Give me pls more information", 7);

            return handlings;
        }
        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<UserSupportDBContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<UserSupportDBContext>();
                builder.UseInMemoryDatabase("UserSupDB");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<UserSupportDBContext>().LifestyleTransient());

            InitializeDbContext(container);
        }
        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<UserSupportDBContext>())
            {
                context.Handlings.AddRange(InitHandlings());

                context.SaveChanges();
            }
        }
    }
}

