using FoodEx.Data;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodEx.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetUserOrdersAsync(string userId);
        Task<List<Order>> GetRestaurantOrdersAsync(string restaurantOwnerId);
        Task<List<Order>> GetDeliveryOrdersAsync(ApplicationUser deliveryUser);
        Task<List<Order>> GetAvailableDeliveryOrdersAsync();
        Task<bool> ClaimOrderAsync(int orderId, string deliveryUserId);
        Task<bool> UpdateOrderStatusByRestaurantAsync(int orderId, OrderStatus status);
        Task<bool> UpdateOrderStatusByDeliveryAsync(int orderId, OrderStatus status, string deliveryUserId);
    }
}
