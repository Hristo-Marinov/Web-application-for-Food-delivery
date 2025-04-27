using FoodEx.Data.Entity.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class HomeServiceTests
    {
        private ApplicationDbContext _context;
        private HomeService _homeService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "HomeServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _homeService = new HomeService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetRestaurantCountAsync_ReturnsCorrectCount()
        {
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Test1", Location = "Loc", Phone = "123", OwnerUserId = "owner1" });
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Test2", Location = "Loc", Phone = "456", OwnerUserId = "owner2" });
            await _context.SaveChangesAsync();

            var count = await _homeService.GetRestaurantCountAsync();

            Assert.AreEqual(2, count);
        }

        [Test]
        public async Task GetFoodCountAsync_ReturnsCorrectCount()
        {
            await _context.Foods.AddAsync(new Food { Name = "Pizza", Description = "Tasty", Price = 10, Category = "Main", ImageUrl = "img.jpg", Restaurant = new Restaurant { Name = "Test", Location = "Loc", Phone = "123", OwnerUserId = "owner" } });
            await _context.SaveChangesAsync();

            var count = await _homeService.GetFoodCountAsync();

            Assert.AreEqual(1, count);
        }

        [Test]
        public async Task GetDeliveryGuyCountAsync_ReturnsCorrectCount()
        {
            var deliveryRole = new IdentityRole { Id = "role1", Name = "DeliveryGuy", NormalizedName = "DELIVERYGUY" };
            await _context.Roles.AddAsync(deliveryRole);
            var user = new ApplicationUser { Id = "user1", UserName = "delivery1" };
            await _context.Users.AddAsync(user);
            await _context.UserRoles.AddAsync(new IdentityUserRole<string> { RoleId = deliveryRole.Id, UserId = user.Id });
            await _context.SaveChangesAsync();

            var count = await _homeService.GetDeliveryGuyCountAsync();

            Assert.AreEqual(1, count);
        }

        [Test]
        public async Task GetAllRestaurantsAsync_ReturnsAllRestaurants()
        {
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Test1", Location = "Loc", Phone = "123", OwnerUserId = "owner1" });
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Test2", Location = "Loc", Phone = "456", OwnerUserId = "owner2" });
            await _context.SaveChangesAsync();

            var restaurants = await _homeService.GetAllRestaurantsAsync();

            Assert.AreEqual(2, restaurants.Count);
            Assert.IsTrue(restaurants.Any(r => r.Name == "Test1"));
            Assert.IsTrue(restaurants.Any(r => r.Name == "Test2"));
        }
    }
}
