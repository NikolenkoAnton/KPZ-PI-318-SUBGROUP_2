using App.Configuration;
using App.Stocks.Interfaces;
using App.Stocks.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Example
{
    /// <summary>
    /// Endpoint class for registering the module in the system. This class should be referenced in the main module directly
    /// </summary>
    public class StocksModule : IModule
    {
        /// <summary>
        /// This method initialize additional module dependencies, if it is not possible to use utility interfaces
        /// </summary>
        /// <param name="container"></param>
        public void Initialize(IWindsorContainer container)
        {
            // example of manually registered components
            container.Register(Component.For<IValidateServices>().ImplementedBy<ValidateServices>().LifestyleSingleton());//.LifestyleTransient());
        }
    }
}
