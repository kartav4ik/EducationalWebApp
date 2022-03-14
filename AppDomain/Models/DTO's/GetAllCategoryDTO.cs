namespace AppDomain.Models.DTO_s
{
    public class GetAllCategoryDTO
    {
        public static GetAllCategoryDTO New(Category category) 
            => new()
        {
            Id = category.Id,
            Name = category.Name,
            Products = category.Products.Select(o => NewProductDTO.New(o)).ToList()
        };
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<NewProductDTO> Products { get; set; }
    }
}
