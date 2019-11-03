using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;

namespace App.Goods.Services
{
    public class NormalizeService : INormalizeService, ITransientDependency
    {
        private readonly IProductsManager _productsManager;

        public NormalizeService(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        public void CleanIds(List<int> ids)
        {
            var goods = _productsManager.GetAllProducts().Select(good => good.Id);

            for (int i = 0; i < ids.Count; i++)
            {
                int id = ids[i];
                if (!goods.Contains(id))
                {
                    ids.Remove(id);
                }
            }
        }
    }
}
