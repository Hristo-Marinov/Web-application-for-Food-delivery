using FoodEx.Data.Entity;
using FoodEx.Data.Entity.Context;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class FoodService : IFoodService
{
    private readonly ApplicationDbContext _context;

    public FoodService(ApplicationDbContext context)
    {
        _context = context;
    }

    public FoodViewModel GetFoodDetails(int id)
    {
        return _context.Foods
            .Where(f => f.FoodId == id)
            .Select(f => new FoodViewModel
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Description = f.Description,
                Price = f.Price,
                RestaurantName = f.Restaurant.Name,
                ImageUrl = f.ImageUrl
            }).FirstOrDefault();
    }

    public async Task AddFoodToCartAsync(int foodId, string userId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
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
    }
}
