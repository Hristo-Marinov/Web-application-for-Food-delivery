namespace FoodEx.Models
{
    public class RatingViewModel
    {
        public int RatingId { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
