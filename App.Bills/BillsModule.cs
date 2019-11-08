using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Bills
{
    public class BillsModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<IValidateServices>().ImplementedBy<ValidateServices>().LifestyleSingleton());
        }
    }
}
