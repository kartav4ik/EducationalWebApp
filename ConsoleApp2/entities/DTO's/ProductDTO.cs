
namespace Domain.Models.DTO_s
{
    public class ProductDTO
    {
        public static ProductDTO New(Product product) 
            => new()
            {
                Id = product.Id,   
                Name = product.Name,
                Price = product.Price,
                Category = product.Categories.Select(c => CategoryDTO.New(c)).ToList(),
                Order = product.Orders.Select(o => OrderDTO.New(o)).ToList()
            };

        //[HiddenInput(DisplayValue = false)]
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<CategoryDTO>? Category { get; set; }
        public ICollection<OrderDTO>? Order { get; set; }

    }
}
//создать DTO для гета по айди 