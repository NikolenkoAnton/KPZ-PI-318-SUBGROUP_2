using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Stocks
{
    public class StocksModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<IValidateServices>().ImplementedBy<ValidateServices>().LifestyleSingleton());
        }
    }
}
