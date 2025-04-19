using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FoodEx.Data;
using FoodEx.Models;
using FoodEx.Services;
using System.Threading.Tasks;
using FoodEx.Entity;

namespace FoodEx.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FoodController(IFoodService foodService, UserManager<ApplicationUser> userManager)
        {
            _foodService = foodService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> FoodDetails(int id)
        {
            var foodViewModel = await _foodService.GetFoodDetailsAsync(id);
            if (foodViewModel == null)
            {
                return NotFound();
            }

            return View("~/Views/Food/FoodDetails.cshtml", foodViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> OrderNow(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _foodService.AddToCartAsync(userId, id);
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitRating(int foodId, int ratingValue, string comment)
        {
            var user = await _userManager.GetUserAsync(User);
            await _foodService.SubmitRatingAsync(foodId, user.Id, ratingValue, comment);
            return RedirectToAction("FoodDetails", new { id = foodId });
        }
    }
}
