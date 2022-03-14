namespace Domain.Models.DTO_s
{
    public class CategoryDTO
    {
        public static CategoryDTO New(Category category) => new()
        {
            Name = category.Name
        };
        public string Name { get; set; }

    }
}
