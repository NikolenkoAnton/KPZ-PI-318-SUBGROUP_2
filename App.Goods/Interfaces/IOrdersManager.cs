using System.Collections.Generic;
using App.Goods.Models;

namespace App.Goods.Interfaces
{
    public interface IOrdersManager
    {
        void MakeOrder(int[] products);
        IEnumerable<Order> GetAllOrders();
    }
}
