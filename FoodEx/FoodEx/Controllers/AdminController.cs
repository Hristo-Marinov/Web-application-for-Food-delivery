using FoodEx.Data;
using FoodEx.Data.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly AdminService _adminService;

        public AdminController(UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                ApplicationDbContext context,
                                AdminService adminService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _adminService = adminService;
        }

        public async Task<IActionResult> AdminPanel()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new List<(ApplicationUser User, string Role)>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add((user, roles.FirstOrDefault() ?? "None"));
            }

            var orders = await _context.Orders.Include(o => o.User).ToListAsync();
            ViewBag.Orders = orders;

            var ratings = await _context.Ratings.Include(r => r.User).Include(r => r.Food).ToListAsync();
            ViewBag.Ratings = ratings;

            var deliveredOrders = await _adminService.GetDeliveredOrdersAsync();
            ViewBag.DeliveredOrders = deliveredOrders;

            var deliveredOrdersGrouped = deliveredOrders
                .Where(o => o.DeliveryGuyId != null)
                .GroupBy(o => o.DeliveryGuyId)
                .Select(g => new
                {
                    deliveryGuyName = _context.Users
                    .Where(u => u.Id == g.Key)
                    .Select(u => u.UserName)
                    .FirstOrDefault() ?? "Unknown",
                     count = g.Count()
                })
                .ToList();


            ViewBag.DeliveredOrdersGrouped = deliveredOrdersGrouped;

            return View(userRoles);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleVerification(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            user.LockoutEnabled = !user.LockoutEnabled;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return NotFound();

            order.Status = newStatus;
            await _context.SaveChangesAsync();

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRating(int ratingId)
        {
            var rating = await _context.Ratings.FindAsync(ratingId);
            if (rating == null) return NotFound();

            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();

            return RedirectToAction("AdminPanel");
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Category added successfully!";
                return RedirectToAction("AdminPanel"); 
            }

            return View(category);
        }
    }
}
