using FoodEx.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using FoodEx.Models;
using FoodEx.Services;

namespace FoodEx.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;

        public CheckoutController(UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            _userManager = userManager;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["CheckoutModel"] = JsonSerializer.Serialize(model);
            return RedirectToAction("Submit");
        }

        [HttpPost]
        public async Task<IActionResult> Submit(CheckoutViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            var success = await _cartService.CheckoutAsync(userId, model);

            if (success)
                return RedirectToAction("UserOrders", "Orders");

            ModelState.AddModelError("", "Checkout failed.");
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult ConfirmAddress(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            return View("ConfirmAddress", model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitConfirmed(CheckoutViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            var success = await _cartService.CheckoutAsync(userId, model);

            if (success)
                return RedirectToAction("UserOrders", "Orders");

            ModelState.AddModelError("", "Checkout failed.");
            return View("ConfirmAddress", model);
        }

    }
}
