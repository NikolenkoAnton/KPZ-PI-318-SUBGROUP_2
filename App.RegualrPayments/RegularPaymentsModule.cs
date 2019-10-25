using App.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.RegularPayments.Interfaces;



namespace App.RegularPayments
{
    public class RegularPaymentsModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<IRegularPaymentsManager>().ImplementedBy<RegularPaymentsManager>().LifestyleSingleton());
        }
    }
}
