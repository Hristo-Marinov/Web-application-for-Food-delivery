using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodEx.Entity;
using FoodEx.Entity.Context;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Models;

namespace FoodEx.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FoodController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult FoodDetails(int id)
        {
            var food = _context.Foods
                .Where(f => f.FoodId == id)
                .Select(f => new FoodViewModel
                {
                    FoodId = f.FoodId,
                    Name = f.Name,
                    Description = f.Description,
                    Price = f.Price,
                    RestaurantName = f.Restaurant.Name
                }).FirstOrDefault();

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
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.Items.FirstOrDefault(ci => ci.FoodId == id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { FoodId = id, Quantity = 1 });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Cart");
        }
    }
}
