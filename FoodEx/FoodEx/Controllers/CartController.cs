using FoodEx.Entity;
using FoodEx.Entity.Context;
using FoodEx.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Food)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var viewModel = new CartViewModel
            {
                Items = cart?.Items.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.CartItemId,
                    FoodId = ci.FoodId,
                    FoodName = ci.Food.Name,
                    Quantity = ci.Quantity,
                    Price = ci.Food.Price,
                    ImageUrl = ci.Food.ImageUrl
                }).ToList() ?? new List<CartItemViewModel>()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AddToCart(int foodId)
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(ci => ci.FoodId == foodId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { FoodId = foodId, Quantity = 1 });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);

            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Food)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index");
            }

            var restaurantId = cart.Items.First().Food.RestaurantId;

            var order = new Order
            {
                UserId = user.Id,
                RestaurantId = restaurantId,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                DeliveryAddressId = _context.Addresses.FirstOrDefault(a => a.UserId == user.Id)?.AddressId,
                TotalPrice = cart.Items.Sum(i => i.Food.Price * i.Quantity),
                OrderItems = cart.Items.Select(ci => new OrderItem
                {
                    FoodId = ci.FoodId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Food.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.Items);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserOrders", "Orders");
        }
    }
}