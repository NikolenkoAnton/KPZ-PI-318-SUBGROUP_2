using Castle.Windsor;
using Castle.MicroKernel.Registration;
using App.Configuration;

namespace App.Stocks
{
    public class StocksModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            // example of manually registered components
            //container.Register(Component.For<IAnotherService>().ImplementedBy<AnotherService>().LifestyleTransient());
        }
    }
}
