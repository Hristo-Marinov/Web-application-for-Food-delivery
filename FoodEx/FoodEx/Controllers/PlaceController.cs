using Microsoft.AspNetCore.Mvc;
using FoodEx.Services;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public async Task<IActionResult> Place()
        {
            var restaurants = await _placeService.GetAllRestaurantsAsync();
            return View(restaurants);
        }

        public async Task<IActionResult> PlaceDetails(int id)
        {
            var restaurant = await _placeService.GetRestaurantWithFoodsAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

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
    }
}
