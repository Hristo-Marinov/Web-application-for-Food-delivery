using FoodEx.Data.Entity;
using FoodEx.Data;
using FoodEx.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Context;

public class DeliveryService : IDeliveryService
{
    private readonly ApplicationDbContext _context;

    public DeliveryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAvailableOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Food)
            .Include(o => o.Restaurant)
            .Where(o => o.Status == OrderStatus.HandedToDelivery && o.DeliveryGuyId == null)
            .ToListAsync();
    }

    public async Task<List<Order>> GetMyOrdersAsync(string deliveryGuyId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Food)
            .Include(o => o.Restaurant)
            .Where(o => o.DeliveryGuyId == deliveryGuyId)
            .ToListAsync();
    }

    public async Task<bool> ClaimOrderAsync(int orderId, string deliveryGuyId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        if (order == null || order.DeliveryGuyId != null) return false;

        order.DeliveryGuyId = deliveryGuyId;
        order.Status = OrderStatus.OutForDelivery;
        await _context.SaveChangesAsync();
        return true;
    }
}
