using FoodEx.Data;
using FoodEx.Data.Entity;
using FoodEx.Data.Entity.Context;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Where(o => o.Status != OrderStatus.HandedToDelivery && o.Status != OrderStatus.Delivered)
                .Where(o => o.RestaurantId == restaurant.RestaurantId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetDeliveryOrdersAsync(ApplicationUser deliveryUser)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Include(o => o.DeliveryAddress)
                .Where(o => o.DeliveryGuyId == deliveryUser.Id && o.Status != OrderStatus.Delivered)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAvailableDeliveryOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.Status == OrderStatus.HandedToDelivery && o.DeliveryGuyId == null)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Food)
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    Status = o.Status,
                    DeliveryAddress = new Address
                    {
                        Street = o.DeliveryAddress.Street
                    },
                    OrderItems = o.OrderItems.Select(oi => new OrderItem
                    {
                        Food = new Food { Name = oi.Food.Name },
                        Quantity = oi.Quantity
                    }).ToList()
                })
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

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderViewModel>> GetOrdersForDeliveryAsync()
        {
            return await _context.Orders
                .Include(o => o.DeliveryAddress)
                .Where(o => o.Status == OrderStatus.HandedToDelivery)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.OrderId,
                    DeliveryGuyId = o.DeliveryGuyId,
                    DeliveryAddressId = o.DeliveryAddressId,
                    FullAddress = o.DeliveryAddress != null
                        ? o.DeliveryAddress.Street
                        : null
                })
                .ToListAsync();
        }
        public async Task<List<Order>> GetUserDeliveredOrdersAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .Include(o => o.DeliveryAddress)
                .Where(o => o.UserId == userId && o.Status == OrderStatus.Delivered)
                .ToListAsync();
        }
    }
}
