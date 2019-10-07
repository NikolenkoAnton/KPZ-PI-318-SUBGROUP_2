using App.Configuration;
using App.Goods.Interfaces;
using App.Goods.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace App.Goods
{
    public class GoodsModule : IModule
    {
        public void Initialize(IWindsorContainer container)
        {
        }
    }
}
