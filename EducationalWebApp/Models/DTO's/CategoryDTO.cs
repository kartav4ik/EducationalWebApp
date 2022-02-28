namespace EducationalWebApp.Models.DTO_s
{
    public class CategoryDTO
    {
        public CategoryDTO(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
          
        }
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
