namespace FoodEx.Models
{
    public class FoodViewModel
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
