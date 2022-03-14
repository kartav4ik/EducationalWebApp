﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public ICollection<Product>? Products { get; set; } 

        public static Order New(DateTime OrderDate, DateTime ShipmentDate) 
            => new()
        {
            Id = Guid.NewGuid(),
            OrderDate = OrderDate,  
            ShipmentDate = ShipmentDate,
            Products = new List<Product>()
        };
    }
}
