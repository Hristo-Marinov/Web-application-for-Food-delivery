namespace FoodEx.Models
{
    public class UserFavoriteViewModel
    {
        public int FavoriteId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
