namespace EducationalWebApp.Models.DTO_s
{
    public class NewProductDTO
    {
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public List<int> CategoriesId { get; set; }
        public List<int> OrdersId { get; set; }
    }
}
