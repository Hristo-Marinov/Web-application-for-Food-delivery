using FoodEx.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Entity;
using FoodEx.Data.Context;

namespace FoodEx.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDbContext _context;

        public RestaurantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> GetRestaurantByOwnerIdAsync(string ownerId)
        {
            return await _context.Restaurants
                .Include(r => r.Foods)
                .FirstOrDefaultAsync(r => r.OwnerUserId == ownerId);
        }

        public async Task<bool> CreateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddFoodAsync(string ownerId, Food food)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.OwnerUserId == ownerId);
            if (restaurant == null) return false;

            food.RestaurantId = restaurant.RestaurantId;
            _context.Foods.Add(food);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFoodAsync(int foodId)
        {
            var food = await _context.Foods.FindAsync(foodId);
            if (food == null) return false;

            _context.Foods.Remove(food);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
