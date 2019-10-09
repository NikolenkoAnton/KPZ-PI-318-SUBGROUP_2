using System.Collections.Generic;
using App.Goods.Models;

namespace App.Goods.Common
{
    public interface IOrdersManager
    {
        Order MakeOrder(IEnumerable<int> products);
        IEnumerable<Order> GetAllOrders();
    }
}
