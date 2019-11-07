using System.Collections.Generic;
using System.Linq;
using App.Configuration;
using App.Goods.Common;
using App.Goods.Exceptions;

namespace App.Goods.Services
{
    public class ValidateService : IValidateService, ITransientDependency
    {
        private readonly IProductsManager _productsManager;

        public ValidateService(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        public void ValidateIds(List<int> ids)
        {
            if (!ids.Any())
            {
                throw new EmptyOrderException("Order product list is empty");
            }

            var goods = _productsManager.GetAllProducts().Select(good => good.Id);
            var wrongIds = new List<int>();

            foreach (var id in ids)
            {
                if (!goods.Contains(id))
                {
                    wrongIds.Add(id);
                }
            }

            if (wrongIds.Any())
            {
                throw new ProductNotFoundException(wrongIds);
            }
        }
    }
}
