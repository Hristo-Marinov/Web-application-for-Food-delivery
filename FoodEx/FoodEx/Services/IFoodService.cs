using FoodEx.Models;
using System.Threading.Tasks;

public interface IFoodService
{
    Task<FoodViewModel> GetFoodDetailsAsync(int foodId);
    Task AddToCartAsync(string userId, int foodId);
    Task SubmitRatingAsync(int foodId, string userId, int ratingValue, string comment);
}
