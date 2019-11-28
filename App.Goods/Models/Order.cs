using System.Collections.Generic;
using App.Goods.Common;

namespace App.Goods.Models
{
    public class Order : IModel
    {
        public int Id { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
