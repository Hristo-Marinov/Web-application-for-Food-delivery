using FoodEx.Entity;

namespace FoodEx.Data.Entity
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
