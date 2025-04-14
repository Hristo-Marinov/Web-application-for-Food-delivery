using FoodEx.Data.Entity;
using FoodEx.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodEx.Services
{
    public interface IHomeService
    {
        Task<int> GetRestaurantCountAsync();
        Task<int> GetFoodCountAsync();
        Task<int> GetDeliveryGuyCountAsync();
        Task<List<Restaurant>> GetAllRestaurantsAsync();
    }
}
