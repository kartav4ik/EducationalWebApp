namespace Domain.Models.DTO_s
{
    public class GetAllCategoryDTO
    {
        public static GetAllCategoryDTO New(Category category) 
            => new()
        {
            Name = category.Name,
            Products = category.Products.Select(o => NewProductDTO.New(o)).ToList()
        };
        public string Name { get; set; }
        public ICollection<NewProductDTO> Products { get; set; }
    }
}
