using System.ComponentModel.DataAnnotations;

namespace MMTTest.API.Models
{
    public class Product
    {
        [Key]
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
