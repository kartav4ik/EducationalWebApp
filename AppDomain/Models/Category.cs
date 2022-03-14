using System.ComponentModel.DataAnnotations;

namespace AppDomain.Models
{
    public class Category
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }

        public static Category New(string Name) 
            => new()
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Products = new List<Product>()
        };

        public static Category New(Category category)
            => new()
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products
            };
    }
}
