using FoodEx.Data.Entity;
using FoodEx.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDeliveryService
{
    Task<List<Order>> GetAvailableOrdersAsync();
    Task<List<Order>> GetMyOrdersAsync(string deliveryGuyId);
    Task<bool> ClaimOrderAsync(int orderId, string deliveryGuyId);
}
