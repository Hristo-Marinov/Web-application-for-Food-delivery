namespace FoodEx.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DeliveryGuyId { get; set; }
        public string DeliveryGuyName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int? DeliveryAddressId { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
