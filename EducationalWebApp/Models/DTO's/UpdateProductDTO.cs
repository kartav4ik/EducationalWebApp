namespace EducationalWebApp.Models.DTO_s
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public List<int> CategoriesId { get; set; }
        public List<int> OrdersId { get; set; }
    }
}
