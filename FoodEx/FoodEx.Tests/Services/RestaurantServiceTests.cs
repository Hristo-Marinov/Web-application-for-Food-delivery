using FoodEx.Data.Entity.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        private ApplicationDbContext _context;
        private RestaurantService _restaurantService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RestaurantServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _restaurantService = new RestaurantService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetRestaurantByOwnerIdAsync_ReturnsCorrectRestaurant()
        {
            var restaurant = new Restaurant { Name = "Italian Place", Location = "City Center", Phone = "123456", OwnerUserId = "owner1" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var result = await _restaurantService.GetRestaurantByOwnerIdAsync("owner1");

            Assert.IsNotNull(result);
            Assert.AreEqual("Italian Place", result.Name);
        }

        [Test]
        public async Task CreateRestaurantAsync_CreatesRestaurant()
        {
            var restaurant = new Restaurant { Name = "New Spot", Location = "Downtown", Phone = "654321", OwnerUserId = "owner2" };

            var result = await _restaurantService.CreateRestaurantAsync(restaurant);

            Assert.IsTrue(result);
            Assert.AreEqual(1, await _context.Restaurants.CountAsync());
        }

        [Test]
        public async Task AddFoodAsync_AddsFoodToRestaurant()
        {
            var restaurant = new Restaurant { Name = "Food Court", Location = "Midtown", Phone = "112233", OwnerUserId = "owner3" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Burger", Description = "Tasty Burger", Price = 10, Category = "FastFood", ImageUrl = "burger.jpg" };

            var result = await _restaurantService.AddFoodAsync("owner3", food);

            Assert.IsTrue(result);
            Assert.AreEqual(1, await _context.Foods.CountAsync());
        }

        [Test]
        public async Task DeleteFoodAsync_DeletesFood()
        {
            var restaurant = new Restaurant { Name = "BBQ Grill", Location = "South Side", Phone = "445566", OwnerUserId = "owner4" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Steak", Description = "Juicy Steak", Price = 25, Category = "Meat", ImageUrl = "steak.jpg", RestaurantId = restaurant.RestaurantId };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var result = await _restaurantService.DeleteFoodAsync(food.FoodId);

            Assert.IsTrue(result);
            Assert.AreEqual(0, await _context.Foods.CountAsync());
        }

        [Test]
        public async Task DeleteFoodAsync_ReturnsFalse_WhenFoodNotFound()
        {
            var result = await _restaurantService.DeleteFoodAsync(999);

            Assert.IsFalse(result);
        }
    }
}
