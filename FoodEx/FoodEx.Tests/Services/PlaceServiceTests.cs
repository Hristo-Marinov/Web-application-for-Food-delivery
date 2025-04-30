using FoodEx.Data.Entity;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using FoodEx.Data.Context;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class PlaceServiceTests
    {
        private ApplicationDbContext _context;
        private PlaceService _placeService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "PlaceServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _placeService = new PlaceService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetAllRestaurantsAsync_ReturnsAllRestaurants()
        {
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Pizza Place", Location = "Center", Phone = "111", OwnerUserId = "owner1" });
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Burger Spot", Location = "Uptown", Phone = "222", OwnerUserId = "owner2" });
            await _context.SaveChangesAsync();

            var restaurants = await _placeService.GetAllRestaurantsAsync();

            Assert.AreEqual(2, restaurants.Count);
        }

        [Test]
        public async Task GetRestaurantWithFoodsAsync_ReturnsRestaurantWithFoods()
        {
            var restaurant = new Restaurant { Name = "Test Restaurant", Location = "Downtown", Phone = "333", OwnerUserId = "owner3" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Taco", Description = "Delicious", Price = 5, ImageUrl = "taco.jpg", RestaurantId = restaurant.RestaurantId };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var result = await _placeService.GetRestaurantWithFoodsAsync(restaurant.RestaurantId);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Foods.Count);
        }

        [Test]
        public async Task GetFoodWithRestaurantAsync_ReturnsFoodWithRestaurant()
        {
            var restaurant = new Restaurant { Name = "Cafe", Location = "East Side", Phone = "444", OwnerUserId = "owner4" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Coffee", Description = "Hot Drink", Price = 3, ImageUrl = "coffee.jpg", RestaurantId = restaurant.RestaurantId };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var result = await _placeService.GetFoodWithRestaurantAsync(food.FoodId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Cafe", result.Restaurant.Name);
        }

        [Test]
        public async Task GetRestaurantsAsync_WithSearchTerm_ReturnsFilteredRestaurants()
        {
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Sushi Bar", Location = "Midtown", Phone = "555", OwnerUserId = "owner5" });
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Pasta House", Location = "Old Town", Phone = "666", OwnerUserId = "owner6" });
            await _context.SaveChangesAsync();

            var filtered = await _placeService.GetRestaurantsAsync("Sushi");

            Assert.AreEqual(1, filtered.Count);
            Assert.AreEqual("Sushi Bar", filtered.First().Name);
        }

        [Test]
        public async Task GetRestaurantsAsync_WithoutSearchTerm_ReturnsAllRestaurants()
        {
            await _context.Restaurants.AddAsync(new Restaurant { Name = "Grill House", Location = "South", Phone = "777", OwnerUserId = "owner7" });
            await _context.Restaurants.AddAsync(new Restaurant { Name = "BBQ Joint", Location = "North", Phone = "888", OwnerUserId = "owner8" });
            await _context.SaveChangesAsync();

            var allRestaurants = await _placeService.GetRestaurantsAsync();

            Assert.AreEqual(2, allRestaurants.Count);
        }
    }
}
