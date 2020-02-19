using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Loans
{
    public class LoansModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<IValidateServices>().ImplementedBy<ValidateServices>().LifestyleSingleton());
        }
    }
}
