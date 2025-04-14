using Microsoft.AspNetCore.Mvc;
using FoodEx.Services;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.RestaurantCount = await _homeService.GetRestaurantCountAsync();
            ViewBag.FoodCount = await _homeService.GetFoodCountAsync();
            ViewBag.DeliveryGuyCount = await _homeService.GetDeliveryGuyCountAsync();

            var restaurants = await _homeService.GetAllRestaurantsAsync();
            return View(restaurants);
        }

        public async Task<IActionResult> Place()
        {
            var restaurants = await _homeService.GetAllRestaurantsAsync();
            return View(restaurants);
        }
    }
}
