using FoodEx.Data.Entity;
using FoodEx.Entity;
using System.Collections.Generic;

namespace FoodEx.Models
{
    public class DeliveryPanelViewModel
    {
        public List<Order> AvailableOrders { get; set; }
        public List<Order> MyOrders { get; set; }
    }

}