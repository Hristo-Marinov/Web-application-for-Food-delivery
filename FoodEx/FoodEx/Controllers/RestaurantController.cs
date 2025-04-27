using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    [Authorize(Roles = "Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantController(IRestaurantService restaurantService, UserManager<ApplicationUser> userManager)
        {
            _restaurantService = restaurantService;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyRestaurant()
        {
            var userId = _userManager.GetUserId(User);
            var restaurant = await _restaurantService.GetRestaurantByOwnerIdAsync(userId);
            return View(restaurant);
        }

        [HttpGet]
        public IActionResult CreateRestaurant() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRestaurant(Restaurant model)
        {
            var user = await _userManager.GetUserAsync(User);

            ViewBag.IsVerified = !user.LockoutEnabled;

            model.OwnerUserId = user.Id;

            var success = await _restaurantService.CreateRestaurantAsync(model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to create restaurant.");
                return View(model);
            }

            return RedirectToAction("MyRestaurant");
        }

        public IActionResult AddFood() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFood(Food food)
        {
            var userId = _userManager.GetUserId(User);
            var success = await _restaurantService.AddFoodAsync(userId, food);

            if (!success)
            {
                ModelState.AddModelError("", "Failed to add food.");
                return View(food);
            }

            return RedirectToAction("MyRestaurant");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFood(int id)
        {
            await _restaurantService.DeleteFoodAsync(id);
            return RedirectToAction("MyRestaurant");
        }
    }
}
