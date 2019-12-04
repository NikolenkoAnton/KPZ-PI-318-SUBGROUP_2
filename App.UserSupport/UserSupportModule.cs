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
        private Handling[] handlings = new Handling[5];

        IEnumerable<Handling> InitHandlings()
        {
            handlings[0] = new Handling(new Client("Nikita"), "Some times i have troubles", 2,1);
            handlings[0].status = true;
            handlings[1] = new Handling(new Client("Alina"), "Some times i make troubles", 3,2);
            handlings[2] = new Handling(new Client("Masha"), "Every times i have troubles", 4,3);
            handlings[3] = new Handling(new Client("Lana"), "Some times i have exeptions", 1,4);
            handlings[4] = new Handling(new Client("Anton"), "Some times i have troubles", 5,5);
            handlings[1].WriteAnswer("What happend?",6);
            handlings[2].WriteAnswer("Give me pls more information",7);
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

