using FoodEx.Entity;
using FoodEx.Data.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Entity;

namespace FoodEx.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly ApplicationDbContext _context;

        public PlaceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantWithFoodsAsync(int id)
        {
            return await _context.Restaurants
                .Include(r => r.Foods)
                .FirstOrDefaultAsync(r => r.RestaurantId == id);
        }

        public async Task<Food> GetFoodWithRestaurantAsync(int id)
        {
            return await _context.Foods
                .Include(f => f.Restaurant)
                .FirstOrDefaultAsync(f => f.FoodId == id);
        }
    }
}
