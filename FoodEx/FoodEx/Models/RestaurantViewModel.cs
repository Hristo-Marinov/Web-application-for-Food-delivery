namespace FoodEx.Models
{
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string OwnerUserId { get; set; }
        public string OwnerName { get; set; }
        public bool IsVerified { get; set; }
    }
}
