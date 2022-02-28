using EducationalWebApp.Models.DTO_s;
using System.ComponentModel.DataAnnotations;

namespace EducationalWebApp.Models
{
    public class Product
    {
/*        public Product(NewProductDTO newProduct)
        {
            ProductName = newProduct.ProductName;
            ProductPrice = newProduct.ProductPrice;
        }*/
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Order>? Orders { get; set; }  
    }
}
