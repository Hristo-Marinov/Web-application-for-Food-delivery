namespace FoodEx.Models
{
    public class OrderAssignmentViewModel
    {
        public int OrderAssignmentId { get; set; }
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsDeliveryGuy { get; set; }
    }
}
