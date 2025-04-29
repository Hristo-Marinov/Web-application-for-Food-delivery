using Microsoft.AspNetCore.Mvc;
using FoodEx.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodEx.Data.Context;
using FoodEx.Data.Entity;

namespace FoodEx.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly ApplicationDbContext _context;

        public PlaceController(IPlaceService placeService, ApplicationDbContext context)
        {
            _placeService = placeService;
            _context = context;
        }

        public async Task<IActionResult> PlaceDetails(int id, string category = null)
        {
            var restaurant = await _placeService.GetRestaurantWithFoodsAsync(id);   

            if (restaurant == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(category))
            {
                restaurant.Foods = restaurant.Foods.Where(f => f.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var foodCategories = await _context.Foods
                .Where(f => f.RestaurantId == id)
                .Select(f => f.Category)
                .Distinct()
                .ToListAsync();

            ViewBag.FoodCategories = foodCategories;

            return View("PlaceDetails", restaurant);
        }

        public async Task<IActionResult> FoodDetails(int id)
        {
            var food = await _placeService.GetFoodWithRestaurantAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            return View("FoodDetails", new
            {
                food.FoodId,
                food.Name,
                food.Description,
                food.Price,
                RestaurantName = food.Restaurant?.Name
            });
        }

        public async Task<IActionResult> Place(string searchTerm, string category = null)
        {
            var restaurants = await _placeService.GetRestaurantsAsync(searchTerm);

            if (!string.IsNullOrEmpty(category))
            {
                restaurants = await _context.Restaurants
                .Where(r => r.Foods
                    .Any(f => f.Category.ToLower() == category.ToLower()))  
                .ToListAsync();
            }
            else
            {
                restaurants = await _placeService.GetRestaurantsAsync(null);
            }

            var foodCategories = await _context.Foods
            .Select(f => f.Category)
            .Distinct()
            .ToListAsync();

            //ViewBag.FoodCategories = foodCategories;
            ViewBag.FoodCategories = foodCategories;
            ViewBag.SearchTerm = searchTerm;
            return View(restaurants);
        }
    }
}
