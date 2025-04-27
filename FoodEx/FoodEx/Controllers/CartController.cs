using FoodEx.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
    {
        _cartService = cartService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var model = await _cartService.GetCartViewModelAsync(userId);
        return View(model);
    }

    public async Task<IActionResult> AddToCart(int foodId)
    {
        var userId = _userManager.GetUserId(User);
        await _cartService.AddToCartAsync(userId, foodId);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveFromCart(int cartItemId)
    {
        await _cartService.RemoveFromCartAsync(cartItemId);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Checkout()
    {
        return RedirectToAction("Index", "Checkout");
    }
}