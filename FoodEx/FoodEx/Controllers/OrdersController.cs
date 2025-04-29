using FoodEx.Data;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using FoodEx.Services;
using MyEmailSender = FoodEx.Services.IEmailSender;


namespace FoodEx.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IDeliveryService _deliveryService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly MyEmailSender _emailSender;

        public OrdersController(IOrderService orderService, IDeliveryService deliveryService, UserManager<ApplicationUser> userManager, IConfiguration configuration, MyEmailSender emailSender)
        {
            _orderService = orderService;
            _deliveryService = deliveryService;
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> UserOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _orderService.GetUserOrdersAsync(userId);
            return View("UserOrders", orders);
        }

        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> RestaurantPanel()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _orderService.GetRestaurantOrdersAsync(userId);
            return View("RestaurantPanel", orders);
        }

        [Authorize(Roles = "DeliveryGuy")]
        public async Task<IActionResult> DeliveryPanel()
        {
            var user = await _userManager.GetUserAsync(User);

            var availableOrders = await _orderService.GetAvailableDeliveryOrdersAsync();
            var myOrders = await _orderService.GetDeliveryOrdersAsync(user);

            var model = new DeliveryPanelViewModel
            {
                AvailableOrders = availableOrders,
                MyOrders = myOrders,
                IsVerified = !user.LockoutEnabled
            };

            ViewBag.IsVerified = !user.LockoutEnabled;

            return View("DeliveryPanel", model);
        }

        [HttpPost]
        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> UpdateOrderStatusByRestaurant(int orderId, OrderStatus status)
        {
            var result = await _orderService.UpdateOrderStatusByRestaurantAsync(orderId, status);
            if (!result) return NotFound();

            var order = await _orderService.GetOrderByIdAsync(orderId);
            await SendOrderStatusEmailAsync(order.User.Email, order.OrderId, status);

            if (status == OrderStatus.Declined)
            {
                await SendOrderStatusEmailAsync(order.User.Email, order.OrderId, status);
            }

            return RedirectToAction("RestaurantPanel");
        }

        [HttpPost]
        [Authorize(Roles = "DeliveryGuy")]
        public async Task<IActionResult> UpdateOrderStatusByDelivery(int orderId, OrderStatus status)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _orderService.UpdateOrderStatusByDeliveryAsync(orderId, status, userId);
            if (!result) return NotFound();

            var order = await _orderService.GetOrderByIdAsync(orderId);
            await SendOrderStatusEmailAsync(order.User.Email, order.OrderId, status);

            return RedirectToAction("DeliveryPanel");
        }

        [HttpPost]
        [Authorize(Roles = "DeliveryGuy")]
        public async Task<IActionResult> ClaimOrder(int orderId)
        {
            var userId = _userManager.GetUserId(User);
            var success = await _orderService.ClaimOrderAsync(orderId, userId);
            if (success)
            {
                var order = await _orderService.GetOrderByIdAsync(orderId);
                await SendOrderStatusEmailAsync(order.User.Email, order.OrderId, order.Status);
            }
            return RedirectToAction("DeliveryPanel");
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> PreviousOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _orderService.GetUserDeliveredOrdersAsync(userId);
            return View("PreviousOrders", orders);
        }

        [Authorize(Roles = "Admin,Restaurant,DeliveryGuy")]
        public IActionResult StaffOverview()
        {
            return View("StaffOverview");
        }

        [Authorize(Roles = "User")]
        public IActionResult UserOverview()
        {
            return View("UserOverview");
        }

        private async Task SendOrderStatusEmailAsync(string toEmail, int orderId, OrderStatus status)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);

            if (order == null) return;

            var foodDetails = string.Join("<br>", order.OrderItems.Select(oi => $"{oi.Food.Name}: {oi.Quantity}"));

            var body = $@"
            <h2>Your Order has Status Update</h2>
            <p>Your order is now: <strong>{status}</strong></p>
            <p><strong>Food Items:</strong></p>
            <p>{foodDetails}</p>
            <p>Thank you for choosing us!</p>
        ";

            var emailMessage = new EmailMessageViewModel
            {
                To = toEmail,
                Subject = "Order Status Updated",
                Body = body,
                IsHtml = true
            };

            await _emailSender.SendEmailAsync(emailMessage);
        }
    }
}
