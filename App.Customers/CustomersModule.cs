using App.Configuration;
using App.Customers.Models;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Customers
{
    public class CustomersModule
    {
        public void Initialize(IWindsorContainer container)
        {
            container.Register(Component.For<Customer>().ImplementedBy<Customer>());
        }
    }
}
