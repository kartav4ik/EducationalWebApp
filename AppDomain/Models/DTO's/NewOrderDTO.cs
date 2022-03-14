namespace AppDomain.Models.DTO_s
{
    public class NewOrderDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public ICollection<NewProductDTO> Products { get; set; }

        public static NewOrderDTO New(Order order) 
            => new()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            ShipmentDate = order.ShipmentDate,
            Products = new List<NewProductDTO>()

        };
    }
}
