using App.Configuration;
using App.News.Database;
using App.News.Interfaces;
using App.Models.Example;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;

namespace App.News
{
    /// <summary>
    /// Endpoint class for registering the module in the system. This class should be referenced in the main module directly
    /// </summary>
    public class NewsModule : IModule
    {
        /// <summary>
        /// This method initialize additional module dependencies, if it is not possible to use utility interfaces
        /// </summary>
        /// <param name="container"></param>
        public void Initialize(IWindsorContainer container)
        {
            // example of manually registered components
            container.Register(Component.For<INewsManager>().ImplementedBy<NewsManager>().LifestyleTransient());

            RegisterDbContext(container);
        }

        /// <summary>
        /// Performs registering dependencies for using EntityFramework DbContext
        /// For more info, please, visit next respurces:
        /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
        /// </summary>
        private void RegisterDbContext(IWindsorContainer container)
        {
            container.Register(Component.For<DbContextOptions<NewsDbContext>>().UsingFactoryMethod(() =>
            {
                var builder = new DbContextOptionsBuilder<NewsDbContext>();
                // for test purpose we are using InMemory database
                builder.UseInMemoryDatabase("ExampleDb");
                return builder.Options;
            }).LifestyleTransient());

            container.Register(Component.For<NewsDbContext>().LifestyleTransient());

            InitializeDbContext(container);
        }

        /// <summary>
        /// Performs initial seed of data for DbContext
        /// </summary>
        private void InitializeDbContext(IWindsorContainer container)
        {
            // DbContext object is Disposable, so it is needed to use "using" constraction
            using (var context = container.Resolve<NewsDbContext>())
            {
                // add values to the context (without saving)
           
                );
               

                // save changes in the context
                context.SaveChanges();
            }
        }
    }
}