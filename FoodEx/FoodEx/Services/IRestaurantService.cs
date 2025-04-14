using FoodEx.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodEx.Services
{
    public interface IRestaurantService
    {
        Task<Restaurant> GetRestaurantByOwnerIdAsync(string ownerId);
        Task<bool> CreateRestaurantAsync(Restaurant restaurant);
        Task<bool> AddFoodAsync(string ownerId, Food food);
        Task<bool> DeleteFoodAsync(int foodId);
    }
}