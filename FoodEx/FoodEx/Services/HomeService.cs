using FoodEx.Entity;
using FoodEx.Data.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Entity;

namespace FoodEx.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetRestaurantCountAsync()
        {
            return await _context.Restaurants.CountAsync();
        }

        public async Task<int> GetFoodCountAsync()
        {
            return await _context.Foods.CountAsync();
        }

        public async Task<int> GetDeliveryGuyCountAsync()
        {
            var deliveryRoleId = await _context.Roles
                .Where(r => r.Name == "DeliveryGuy")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            return await _context.Users
                .Where(u => _context.UserRoles
                    .Any(ur => ur.RoleId == deliveryRoleId && ur.UserId == u.Id))
                .CountAsync();
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }
    }
}
