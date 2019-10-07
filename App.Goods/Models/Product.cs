using App.Goods.Interfaces;

namespace App.Goods.Models
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
