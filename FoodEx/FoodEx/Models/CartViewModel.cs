using FoodEx.Entity;

namespace FoodEx.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<CartItemViewModel> Items { get; set; }
        public decimal TotalPrice => Items?.Sum(i => i.Total) ?? 0;
    }
}
