using FoodEx.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using FoodEx.Models;
using FoodEx.Services;
using FoodEx.Data.Entity;
using MyEmailSender = FoodEx.Services.IEmailSender;
using FoodEx.Data.Context;

namespace FoodEx.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ICartService _cartService;
        private readonly MyEmailSender _emailSender;

        public CheckoutController(UserManager<ApplicationUser> userManager, ICartService cartService, MyEmailSender emailSender, ApplicationDbContext context)
        {
            _userManager = userManager;
            _cartService = cartService;
            _emailSender = emailSender;
            _context = context;
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

            // Perform checkout process
            var success = await _cartService.CheckoutAsync(userId, model);

            if (success)
            {
                var user = await _userManager.FindByIdAsync(userId);
                var userEmail = user?.Email;

                var subject = "Your Order has been Confirmed!";
                var body = $"Dear Customer, your order has been successfully placed. Thank you for shopping with us!";
                var isHtml = true;

                // Create the EmailMessageViewModel
                var emailMessage = new EmailMessageViewModel
                {
                    To = userEmail,
                    Subject = subject,
                    Body = body,
                    IsHtml = isHtml
                };

                // Send email using the EmailSender service
                await _emailSender.SendEmailAsync(emailMessage);

                return RedirectToAction("UserOrders", "Orders");
            }

            ModelState.AddModelError("", "Checkout failed.");
            return View("ConfirmAddress", model);
        }

    }
}
