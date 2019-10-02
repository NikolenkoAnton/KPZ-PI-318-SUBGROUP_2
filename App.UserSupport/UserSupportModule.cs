using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.UserSupport
{
    public class UserSupportModule : IModule
    {
        /// <summary>
        /// This method initialize additional module dependencies, if it is not possible to use utility interfaces
        /// </summary>
        /// <param name="container"></param>
        public void Initialize(IWindsorContainer container)
        {
            // example of manually registered components
            container.Register(Component.For<IAnotherService>().ImplementedBy<AnotherService>().LifestyleTransient());
        }
    }
}
