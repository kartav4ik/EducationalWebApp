namespace EducationalWebApp.Models.DTO_s
{
    public class ProductDTO
    {
        public ProductDTO(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            ProductPrice = product.ProductPrice;
            Category = product.Categories.Select(c => new CategoryDTO(c)).ToList();
            Order = product.Orders.Select(o => new OrderDTO(o)).ToList();

        }
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public long ProductPrice { get; set; }
        public ICollection<CategoryDTO>? Category { get; set; }
        public ICollection<OrderDTO>? Order { get; set; }

    }
}
