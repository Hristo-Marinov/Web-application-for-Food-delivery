using FoodEx.Data.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    [Authorize(Roles = "Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public RestaurantController(IRestaurantService restaurantService, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _restaurantService = restaurantService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> MyRestaurant()
        {
            var userId = _userManager.GetUserId(User);
            var restaurant = await _restaurantService.GetRestaurantByOwnerIdAsync(userId);
            return View(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRestaurant()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.IsVerified = user != null && user.LockoutEnabled; 
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRestaurant(Restaurant model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(model);
            }

            
            if (user.LockoutEnabled)
            {
                ModelState.AddModelError("", "Your account is not verified yet.");
                ViewBag.IsVerified = false;
                return View(model);
            }

            ViewBag.IsVerified = true;
            model.OwnerUserId = user.Id;

            var success = await _restaurantService.CreateRestaurantAsync(model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to create restaurant.");
                return View(model);
            }

            return RedirectToAction("MyRestaurant");
        }

        [HttpGet]
        public async Task<IActionResult> AddFood()
        {
            var categories = await _context.Categories.ToListAsync();

            var foodViewModel = new FoodViewModel
            {
                Categories = categories
            };

            return View(foodViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFood(FoodViewModel foodViewModel, List<int> selectedCategories)
        {
            if (foodViewModel == null || selectedCategories == null || !selectedCategories.Any())
            {
                ModelState.AddModelError("", "Food data or categories are missing.");
                return View(foodViewModel);
            }

            var restaurant = await _context.Restaurants
                                            .FirstOrDefaultAsync(r => r.OwnerUserId == _userManager.GetUserId(User));

            if (restaurant == null)
            {
                ModelState.AddModelError("", "Restaurant not found.");
                return View(foodViewModel);
            }

            var food = new Food
            {
                Name = foodViewModel.Name,
                Description = foodViewModel.Description,
                Price = foodViewModel.Price,
                ImageUrl = foodViewModel.ImageUrl ?? "default-image.jpg",
                RestaurantId = restaurant.RestaurantId
            };

            foreach (var categoryId in selectedCategories)
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category != null)
                {
                    food.FoodCategories.Add(new FoodCategory
                    {
                        Food = food,
                        Category = category
                    });
                }
            }

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

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
