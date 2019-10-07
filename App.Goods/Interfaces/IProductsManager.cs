using System.Collections.Generic;
using App.Goods.Models;

namespace App.Goods.Interfaces
{
    public interface IProductsManager
    {
        IEnumerable<Product> GetAllGoods();
    }
}
