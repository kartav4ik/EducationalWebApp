using EducationalWebApp.Models.DTO_s;
using System.ComponentModel.DataAnnotations;

namespace EducationalWebApp.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
