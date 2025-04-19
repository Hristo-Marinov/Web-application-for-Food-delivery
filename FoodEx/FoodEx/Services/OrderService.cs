using FoodEx.Entity;
using FoodEx.Data.Entity.Context;
using FoodEx.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Entity;
using FoodEx.Data;

namespace FoodEx.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetUserOrdersAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Include(o => o.Restaurant)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetRestaurantOrdersAsync(string restaurantOwnerId)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.OwnerUserId == restaurantOwnerId);
            if (restaurant == null) return new List<Order>();

            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Where(o => o.RestaurantId == restaurant.RestaurantId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetDeliveryOrdersAsync(ApplicationUser deliveryUser)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Where(o => o.DeliveryGuyId == deliveryUser.Id)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAvailableDeliveryOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Include(o => o.Restaurant)
                .Where(o => o.Status == OrderStatus.HandedToDelivery && o.DeliveryGuyId == null)
                .ToListAsync();
        }

        public async Task<bool> ClaimOrderAsync(int orderId, string deliveryUserId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null || order.Status != OrderStatus.HandedToDelivery || order.DeliveryGuyId != null)
                return false;

            order.DeliveryGuyId = deliveryUserId;
            order.Status = OrderStatus.OutForDelivery;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderStatusByRestaurantAsync(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return false;

            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrderStatusByDeliveryAsync(int orderId, OrderStatus status, string deliveryUserId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null || order.DeliveryGuyId != deliveryUserId)
                return false;

            order.Status = status;

            if (status == OrderStatus.Delivered)
            {
                _context.OrderItems.RemoveRange(order.OrderItems);
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
