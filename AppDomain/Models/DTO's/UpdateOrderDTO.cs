namespace AppDomain.Models.DTO_s
{
    public class UpdateOrderDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
