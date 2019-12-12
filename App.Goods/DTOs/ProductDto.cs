using App.Goods.Models;

namespace App.Goods.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Cost = product.Cost;
        }
    }
}
