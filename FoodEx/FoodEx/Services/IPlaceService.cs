using FoodEx.Data.Entity;
using FoodEx.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodEx.Services
{
    public interface IPlaceService
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantWithFoodsAsync(int id);
        Task<Food> GetFoodWithRestaurantAsync(int id);
    }
}
