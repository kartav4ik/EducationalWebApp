using System.ComponentModel.DataAnnotations;

namespace EducationalWebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShipmentDate { get; set; }
        public int ClientId { get; set; }
        public int EmployeeCode { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}


//как правильно называть поля и таблиц
