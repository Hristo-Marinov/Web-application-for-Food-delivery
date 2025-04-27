using FoodEx.Data.Entity.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class OrderServiceTests
    {
        private ApplicationDbContext _context;
        private OrderService _orderService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _orderService = new OrderService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetUserOrdersAsync_ReturnsCorrectOrders()
        {
            var user = new ApplicationUser { Id = "user1" };
            await _context.Users.AddAsync(user);

            var restaurant = new Restaurant { Name = "TestRes", Location = "Loc", Phone = "123", OwnerUserId = "owner1" };
            await _context.Restaurants.AddAsync(restaurant);

            await _context.Orders.AddAsync(new Order { UserId = user.Id, Restaurant = restaurant });
            await _context.SaveChangesAsync();

            var orders = await _orderService.GetUserOrdersAsync(user.Id);

            Assert.AreEqual(1, orders.Count);
        }

        [Test]
        public async Task GetRestaurantOrdersAsync_ReturnsCorrectOrders()
        {
            var owner = "owner1";
            var restaurant = new Restaurant { Name = "TestRes", Location = "Loc", Phone = "123", OwnerUserId = owner };
            await _context.Restaurants.AddAsync(restaurant);

            await _context.Orders.AddAsync(new Order { Restaurant = restaurant, Status = OrderStatus.Pending });
            await _context.SaveChangesAsync();

            var orders = await _orderService.GetRestaurantOrdersAsync(owner);

            Assert.AreEqual(1, orders.Count);
        }

        [Test]
        public async Task GetAvailableDeliveryOrdersAsync_ReturnsOnlyHandedToDelivery()
        {
            var address = new Address { Street = "Test St", City = "City", Country = "Country", PostalCode = "12345", UserId = "user1" };
            await _context.Addresses.AddAsync(address);

            await _context.Orders.AddAsync(new Order { Status = OrderStatus.HandedToDelivery, DeliveryAddress = address });
            await _context.SaveChangesAsync();

            var orders = await _orderService.GetAvailableDeliveryOrdersAsync();

            Assert.AreEqual(1, orders.Count);
        }

        [Test]
        public async Task ClaimOrderAsync_ClaimsOrderSuccessfully()
        {
            var order = new Order { Status = OrderStatus.HandedToDelivery };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var result = await _orderService.ClaimOrderAsync(order.OrderId, "delivery1");

            Assert.IsTrue(result);

            var updatedOrder = await _context.Orders.FindAsync(order.OrderId);
            Assert.AreEqual("delivery1", updatedOrder.DeliveryGuyId);
            Assert.AreEqual(OrderStatus.OutForDelivery, updatedOrder.Status);
        }

        [Test]
        public async Task UpdateOrderStatusByRestaurantAsync_UpdatesStatusSuccessfully()
        {
            var order = new Order { Status = OrderStatus.Pending };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var result = await _orderService.UpdateOrderStatusByRestaurantAsync(order.OrderId, OrderStatus.HandedToDelivery);

            Assert.IsTrue(result);
            var updatedOrder = await _context.Orders.FindAsync(order.OrderId);
            Assert.AreEqual(OrderStatus.HandedToDelivery, updatedOrder.Status);
        }

        [Test]
        public async Task UpdateOrderStatusByDeliveryAsync_UpdatesStatusSuccessfully()
        {
            var order = new Order { Status = OrderStatus.OutForDelivery, DeliveryGuyId = "delivery1" };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var result = await _orderService.UpdateOrderStatusByDeliveryAsync(order.OrderId, OrderStatus.Delivered, "delivery1");

            Assert.IsTrue(result);
            var updatedOrder = await _context.Orders.FindAsync(order.OrderId);
            Assert.AreEqual(OrderStatus.Delivered, updatedOrder.Status);
        }

        [Test]
        public async Task GetOrdersForDeliveryAsync_ReturnsHandedToDeliveryOrders()
        {
            // Arrange
            var address = new Address
            {
                Street = "123 Main St",
                City = "Test City",
                Country = "Test Country",
                PostalCode = "12345",
                UserId = "test-user-id" // <-- REQUIRED field
            };
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            var order = new Order
            {
                Status = OrderStatus.HandedToDelivery,
                DeliveryAddressId = address.AddressId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Act
            var result = await _orderService.GetOrdersForDeliveryAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(order.OrderId, result.First().OrderId);
            Assert.AreEqual(address.Street, result.First().FullAddress);
        }


        [Test]
        public async Task GetUserDeliveredOrdersAsync_ReturnsDeliveredOrders()
        {
            var userId = "user1";
            await _context.Orders.AddAsync(new Order { UserId = userId, Status = OrderStatus.Delivered });
            await _context.SaveChangesAsync();

            var orders = await _orderService.GetUserDeliveredOrdersAsync(userId);

            Assert.AreEqual(1, orders.Count);
        }
    }
}
