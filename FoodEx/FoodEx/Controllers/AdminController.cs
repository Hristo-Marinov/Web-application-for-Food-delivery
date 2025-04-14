using FoodEx.Data;
using FoodEx.Data.Entity.Context;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public AdminController(UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
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

            order.Status = (Data.OrderStatus)newStatus;
            await _context.SaveChangesAsync();

            return RedirectToAction("AdminPanel");
        }
    }
}
