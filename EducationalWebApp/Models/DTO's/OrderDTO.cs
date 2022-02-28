namespace EducationalWebApp.Models.DTO_s
{
    public class OrderDTO
    {
        public OrderDTO(Order order)
        {
            OrderId = order.OrderId;
            OrderDate = order.OrderDate;   
            ShipmentDate = order.ShipmentDate;  
            ClientId = order.ClientId;
            EmployeeCode = order.EmployeeCode;
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int ClientId { get; set; }
        public int EmployeeCode { get; set; }

    }
}
