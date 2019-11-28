using System.Linq;
using App.Goods.Models;

namespace App.Goods.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public ProductDto[] Products { get; set; }

        public OrderDto(Order order)
        {
            Id = order.Id;
            Products = order.OrderProducts.Select(op => new ProductDto(op.Product)).ToArray();
        }
    }
}
