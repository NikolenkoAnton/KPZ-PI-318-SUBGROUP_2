using System.Collections.Generic;
using App.Goods.DTOs;
using App.Goods.Models;

namespace App.Goods.Common
{
    public interface IOrdersManager
    {
        OrderDto MakeOrder(IEnumerable<int> products);
        IEnumerable<OrderDto> GetAllOrders();
    }
}
