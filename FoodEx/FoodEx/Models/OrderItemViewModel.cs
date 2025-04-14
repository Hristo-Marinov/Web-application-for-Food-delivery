using FoodEx.Data.Entity;

namespace FoodEx.Models
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
