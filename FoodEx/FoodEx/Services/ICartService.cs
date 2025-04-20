using FoodEx.Models;
using System.Threading.Tasks;

public interface ICartService
{
    Task<CartViewModel> GetCartViewModelAsync(string userId);
    Task AddToCartAsync(string userId, int foodId);
    Task RemoveFromCartAsync(int cartItemId);
    Task<bool> CheckoutAsync(string userId);
    Task<bool> CheckoutAsync(string userId, CheckoutViewModel model);
}
