using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppDomain.Models
{
    public class Product
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public ICollection<Category>? Categories { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }

        public static Product New(string Name, decimal Price) => new()
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Price = Price,
            Categories = new List<Category>(),
            Orders = new List<Order>()
        };
        public static Product New(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Categories = product.Categories,
            Orders = product.Orders
        };
    }
}
