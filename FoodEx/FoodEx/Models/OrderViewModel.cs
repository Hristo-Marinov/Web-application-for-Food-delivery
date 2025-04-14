using FoodEx.Data;
using FoodEx.Data.Entity;
using FoodEx.Entity;

namespace FoodEx.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string? DeliveryGuyId { get; set; }
        public ApplicationUser? DeliveryGuy { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int? DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }
        public ICollection<OrderItemViewModel> OrderItems { get; set; }
    }
}
