using FoodEx.Data.Entity;
using FoodEx.Data;
using FoodEx.Entity;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Context;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class AdminServiceTests
    {
        private ApplicationDbContext _context;
        private AdminService _adminService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AdminServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _adminService = new AdminService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetDeliveredOrdersAsync_ReturnsOnlyDeliveredOrders()
        {
            var user = new ApplicationUser { Id = "1", UserName = "testuser", Email = "testuser@example.com", EmailConfirmed = true };
            var address = new Address { AddressId = 1, UserId = "1", Street = "123 Test St", City = "Test City" };

            await _context.Users.AddAsync(user);
            await _context.Addresses.AddAsync(address);
            await _context.Orders.AddRangeAsync(new List<Order>
            {
                new Order { OrderId = 1, UserId = "1", DeliveryAddressId = 1, Status = OrderStatus.Delivered, TotalPrice = 20 },
                new Order { OrderId = 2, UserId = "1", DeliveryAddressId = 1, Status = OrderStatus.Pending, TotalPrice = 30 }
            });

            await _context.SaveChangesAsync();

            var result = await _adminService.GetDeliveredOrdersAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(OrderStatus.Delivered, result.First().Status);
        }
    }
}
