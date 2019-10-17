using App.News.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.Configuration;

namespace App.News
{
   public class NewsModule: IModule
    {
        public void Initialize(IWindsorContainer container)
        {
        }
    }
}
