using System;
using System.Collections.Generic;

namespace App.Goods.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public IEnumerable<int> ProductIds { get; private set; }

        public ProductNotFoundException(IEnumerable<int> productIds)
        {
            ProductIds = productIds;
        }
    }
}
