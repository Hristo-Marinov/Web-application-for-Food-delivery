using FoodEx.Data.Entity;
using FoodEx.Data;
using FoodEx.Data.Entity.Context;
using FoodEx.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdminService
{
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetDeliveredOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.DeliveryAddress)
            .Where(o => o.Status == OrderStatus.Delivered)
            .ToListAsync();
    }
}
