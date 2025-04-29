using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FoodEx.Data.Entity;
using FoodEx.Entity;

namespace FoodEx.Data.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string? DeliveryGuyId { get; set; }
        public ApplicationUser? DeliveryGuy { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int? DeliveryAddressId { get; set; }
        public Address? DeliveryAddress { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public bool PayMethod { get; set; }
    }
}
