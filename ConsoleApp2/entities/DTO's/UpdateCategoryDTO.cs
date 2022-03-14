namespace Domain.Models.DTO_s
{
    public class UpdateCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }   
        public ICollection<Product>? Products { get; set; }
    }
}
