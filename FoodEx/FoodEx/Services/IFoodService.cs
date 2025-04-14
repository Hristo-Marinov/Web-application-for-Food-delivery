using FoodEx.Models;
using System.Threading.Tasks;

public interface IFoodService
{
    FoodViewModel GetFoodDetails(int id);
    Task AddFoodToCartAsync(int foodId, string userId);
}
