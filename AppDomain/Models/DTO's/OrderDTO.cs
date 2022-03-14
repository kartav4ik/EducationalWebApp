namespace AppDomain.Models.DTO_s
{
    public class OrderDTO
    {
        public static OrderDTO New(Order order) => new()
        {
            Id = order.Id,  
            OrderDate = order.OrderDate,
            ShipmentDate = order.ShipmentDate
        };
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }

    }
}
