using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
        public string DeliveryGuyId { get; set; }
        [ForeignKey("DeliveryGuyId")]
        public ApplicationUser DeliveryGuy { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryAddressId { get; set; }
        [ForeignKey("DeliveryAddressId")]
        public Address DeliveryAddress { get; set; }
    }
}
