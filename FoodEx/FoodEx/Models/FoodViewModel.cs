using FoodEx.Data.Entity;

namespace FoodEx.Models
{
    public class FoodViewModel
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public string ImageUrl { get; set; }
        public string RestaurantName { get; set; }
        public double AverageRating { get; set; }
        //public int Quantity { get; set; }

        public List<FoodQuantityViewModel> Foods { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public List<RatingViewModel> Ratings { get; set; } = new List<RatingViewModel>();
        public RatingViewModel NewRating { get; set; } = new RatingViewModel();

        public List<Category> Categories { get; set; }
    }
}
