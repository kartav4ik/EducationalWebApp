namespace AppDomain.Models.DTO_s
{
    public class NewProductDTO
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static NewProductDTO New(Product product) 
            => new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };

    }
}
