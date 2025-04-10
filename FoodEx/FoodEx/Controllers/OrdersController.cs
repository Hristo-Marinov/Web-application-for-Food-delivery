using FoodEx.Entity.Context;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodEx.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> UserOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
            .Include(o => o.Restaurant)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return View("UserOrders", orders);
        }

        // For Restaurant
        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> RestaurantPanel()
        {
            var userId = _userManager.GetUserId(User);
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.OwnerUserId == userId);

            if (restaurant == null) return Unauthorized();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Where(o => o.RestaurantId == restaurant.RestaurantId)
                .ToListAsync();

            return View("RestaurantPanel", orders);
        }

        [Authorize(Roles = "DeliveryGuy")]
        public async Task<IActionResult> DeliveryPanel()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.LockoutEnabled)
            {
                return Unauthorized("Your account is not verified by the admin yet.");
            }

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Where(o => o.Status == OrderStatus.Prepared || (o.DeliveryGuyId != null && o.DeliveryGuyId == user.Id))
                .ToListAsync();

            return View("DeliveryPanel", orders);
        }

        [HttpPost]
        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> UpdateOrderStatusByRestaurant(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return NotFound();

            order.Status = status;
            await _context.SaveChangesAsync();
            return RedirectToAction("RestaurantPanel");
        }

        [HttpPost]
        [Authorize(Roles = "DeliveryGuy")]
        public async Task<IActionResult> UpdateOrderStatusByDelivery(int orderId, OrderStatus status)
        {
            var userId = _userManager.GetUserId(User);
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null) return NotFound();

            order.Status = status;

            if (order.DeliveryGuyId == null)
            {
                order.DeliveryGuyId = userId;
            }

            if (status == OrderStatus.Delivered)
            {
                _context.OrderItems.RemoveRange(order.OrderItems);

                _context.Orders.Remove(order);

                await _context.SaveChangesAsync();

                TempData["Message"] = $"Order #{orderId} marked as delivered and removed from system.";
                return RedirectToAction("DeliveryPanel");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("DeliveryPanel");
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
    }
}

