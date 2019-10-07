using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Interfaces;

namespace App.Goods.Services
{
    public class ValidateService : IValidateService, ITransientDependency
    {
        private readonly IProductsManager _productsManager;

        public ValidateService(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        public IEnumerable<int> ValidateIds(int[] ids)
        {
            var goods = _productsManager.GetAllGoods().Select(good => good.Id);
            var validIds = new List<int>();

            foreach (var id in ids)
            {
                if (goods.Contains(id))
                {
                    validIds.Add(id);
                }
            }

            return validIds;
        }
    }
}
