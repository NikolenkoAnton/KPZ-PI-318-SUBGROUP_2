using Castle.Windsor;

namespace App.Configuration
{
    /// <summary>
    /// Interface, which should be inherited by all custom defined modules
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Endpoint to initialize additional dependencies manually
        /// </summary>
        /// <param name="container"></param>
        void Initialize(IWindsorContainer container);
    }
}
