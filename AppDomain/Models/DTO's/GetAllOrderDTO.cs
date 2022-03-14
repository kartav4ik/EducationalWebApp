namespace AppDomain.Models.DTO_s
{
    public class GetAllOrderDTO
    {
        public static GetAllOrderDTO New(Order order) => new()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            ShipmentDate = order.ShipmentDate,
            Products = order.Products.Select(o => NewProductDTO.New(o)).ToList()
        };
        public Guid Id { get; set; }    
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public ICollection<NewProductDTO> Products { get; set; }
    }
}


