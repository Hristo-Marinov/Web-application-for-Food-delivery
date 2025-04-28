using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.EntityFrameworkCore;
using FoodEx.Data.Entity;
using FoodEx.Data;
using FoodEx.Data.Context;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;

    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CartViewModel> GetCartViewModelAsync(string userId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(ci => ci.Food)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        return new CartViewModel
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
    }

    public async Task AddToCartAsync(string userId, int foodId)
    {
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
    }

    public async Task RemoveFromCartAsync(int cartItemId)
    {
        var item = await _context.CartItems.FindAsync(cartItemId);
        if (item != null)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> CheckoutAsync(string userId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(ci => ci.Food)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null || !cart.Items.Any())
            return false;

        var restaurantId = cart.Items.First().Food.RestaurantId;

        var order = new Order
        {
            UserId = userId,
            RestaurantId = restaurantId,
            OrderDate = DateTime.UtcNow,
            Status = (FoodEx.Data.OrderStatus)OrderStatus.Pending,
            DeliveryAddressId = _context.Addresses.FirstOrDefault(a => a.UserId == userId)?.AddressId,
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

        return true;
    }

    public async Task<bool> CheckoutAsync(string userId, CheckoutViewModel model)
    {
        var user = await _context.Users.FindAsync(userId);
        var cart = await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(i => i.Food)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (user == null || cart == null || !cart.Items.Any())
            return false;

        var address = new Address
        {
            UserId = userId,
            Street = model.Street,
            City = model.City,
            Country = model.Country,
            PostalCode = model.PostalCode
        };
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        var restaurantId = cart.Items.First().Food.RestaurantId;

        var order = new Order
        {
            UserId = userId,
            RestaurantId = restaurantId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            DeliveryAddressId = address.AddressId,
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

        return true;
    }

}
