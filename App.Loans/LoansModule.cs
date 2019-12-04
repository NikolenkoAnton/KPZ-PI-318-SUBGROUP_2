using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.Loans.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace App.Loans
{
    public class LoansModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            RegisterDbContext(container);
        }
        
        IEnumerable<Loan> InitLoans()
        {
            return new Loan[] {    
            new Loan(1,10000, 1, 24),
            new Loan(2,28860, 5, 6),
            new Loan(3,5000, 0.01,3)  };
        }
        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<LoansDBContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<LoansDBContext>();
                builder.UseInMemoryDatabase("LoansDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<LoansDBContext>().LifestyleTransient());

            InitializeDbContext(container);
        }
        private void InitializeDbContext(IWindsorContainer container)
        {
            using (var context = container.Resolve<LoansDBContext>())
            {
                context.Loans.AddRange(InitLoans());

                context.SaveChanges();
            }
        }
    }
}
