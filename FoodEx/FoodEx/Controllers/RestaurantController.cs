using FoodEx.Entity;
using FoodEx.Entity.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    [Authorize(Roles = "Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyRestaurant()
        {
            var userId = _userManager.GetUserId(User);
            var restaurant = await _context.Restaurants
                .Include(r => r.Foods)
                .FirstOrDefaultAsync(r => r.OwnerUserId == userId);

            return View(restaurant);
        }

        [HttpGet]
        public IActionResult CreateRestaurant()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRestaurant(Restaurant model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.LockoutEnabled)
            {
                ModelState.AddModelError("", "Your account is not verified to create a restaurant.");
                return View(model);
            }

            var restaurant = new Restaurant
            {
                Name = model.Name,
                Location = model.Location,
                Phone = model.Phone,
                OwnerUserId = user.Id
            };

            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction("MyRestaurant");
        }



        public IActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFood(Food food)
        {
            var userId = _userManager.GetUserId(User);
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.OwnerUserId == userId);
            if (restaurant == null) return NotFound();

            food.RestaurantId = restaurant.RestaurantId;
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyRestaurant");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyRestaurant");
        }
    }
}
