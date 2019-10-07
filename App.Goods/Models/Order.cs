using App.Goods.Interfaces;

namespace App.Goods.Models
{
    public class Order : IModel
    {
        public int Id { get; set; }
        public Product[] Products { get; set; }
    }
}
