using FoodEx.Entity;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FoodEx.Data.Entity;
using FoodEx.Data;
using FoodEx.Data.Context;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class DeliveryServiceTests
    {
        private ApplicationDbContext _context;
        private DeliveryService _deliveryService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeliveryServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _deliveryService = new DeliveryService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private Order CreateOrder(int id, string status, string deliveryGuyId = null)
        {
            return new Order
            {
                OrderId = id,
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), status),
                DeliveryGuyId = deliveryGuyId,
                Restaurant = new Restaurant
                {
                    Name = "Test Restaurant",
                    Location = "Test Location",
                    Phone = "123456789",
                    OwnerUserId = "owner-id"
                },
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Food = new Food
                        {
                            FoodId = id,
                            Name = "Food" + id,
                            Price = 10,
                            Category = "Main",
                            Description = "Test Description",
                            ImageUrl = "http://testimage.com/food.jpg"
                        },
                        Quantity = 1,
                        UnitPrice = 10
                    }
                }
            };
        }

        [Test]
        public async Task GetAvailableOrdersAsync_ReturnsOnlyHandedToDeliveryOrders()
        {
            await _context.Orders.AddAsync(CreateOrder(1, "HandedToDelivery"));
            await _context.Orders.AddAsync(CreateOrder(2, "Pending"));
            await _context.SaveChangesAsync();

            var result = await _deliveryService.GetAvailableOrdersAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(OrderStatus.HandedToDelivery, result.First().Status);
        }

        [Test]
        public async Task GetMyOrdersAsync_ReturnsOnlyOrdersForDeliveryGuy()
        {
            var deliveryGuyId = "delivery1";
            await _context.Orders.AddAsync(CreateOrder(1, "OutForDelivery", deliveryGuyId));
            await _context.Orders.AddAsync(CreateOrder(2, "OutForDelivery", "delivery2"));
            await _context.SaveChangesAsync();

            var result = await _deliveryService.GetMyOrdersAsync(deliveryGuyId);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(deliveryGuyId, result.First().DeliveryGuyId);
        }

        [Test]
        public async Task ClaimOrderAsync_ClaimsAvailableOrder()
        {
            await _context.Orders.AddAsync(CreateOrder(1, "HandedToDelivery"));
            await _context.SaveChangesAsync();

            var success = await _deliveryService.ClaimOrderAsync(1, "delivery1");

            var updatedOrder = await _context.Orders.FindAsync(1);

            Assert.IsTrue(success);
            Assert.AreEqual("delivery1", updatedOrder.DeliveryGuyId);
            Assert.AreEqual(OrderStatus.OutForDelivery, updatedOrder.Status);
        }

        [Test]
        public async Task ClaimOrderAsync_ReturnsFalse_WhenOrderAlreadyClaimed()
        {
            await _context.Orders.AddAsync(CreateOrder(1, "HandedToDelivery", "someone"));
            await _context.SaveChangesAsync();

            var success = await _deliveryService.ClaimOrderAsync(1, "delivery1");

            Assert.IsFalse(success);
        }
    }
}
