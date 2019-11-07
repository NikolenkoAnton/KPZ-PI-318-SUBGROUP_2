using System.Collections.Generic;

namespace App.Goods.Exceptions
{
    class ProductNotFoundException
    {
        public IEnumerable<int> ProductIds { get; private set; }

        public ProductNotFoundException(IEnumerable<int> productIds)
        {
            ProductIds = productIds;
        }
    }
}
