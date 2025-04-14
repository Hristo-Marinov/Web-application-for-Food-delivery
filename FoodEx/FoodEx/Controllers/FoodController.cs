using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FoodEx.Entity;
using FoodEx.Models;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFoodService _foodService;

        public FoodController(UserManager<ApplicationUser> userManager, IFoodService foodService)
        {
            _userManager = userManager;
            _foodService = foodService;
        }

        [AllowAnonymous]
        public IActionResult FoodDetails(int id)
        {
            var food = _foodService.GetFoodDetails(id);
            if (food == null)
            {
                return NotFound();
            }

            return View("~/Views/Food/FoodDetails.cshtml", food);
        }

        [HttpPost]
        public async Task<IActionResult> OrderNow(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _foodService.AddFoodToCartAsync(id, userId);
            return RedirectToAction("Index", "Cart");
        }
    }
}
