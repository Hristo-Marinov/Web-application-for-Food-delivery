using FoodEx.Data.Context;
using FoodEx.Data.Entity;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        private ApplicationDbContext _context;
        private RestaurantService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{System.Guid.NewGuid()}")
                .Options;
            _context = new ApplicationDbContext(options);
            _service = new RestaurantService(_context);
        }

        [Test]
        public async Task CreateRestaurantAsync_AddsRestaurant()
        {
            var restaurant = new Restaurant { Name = "Test Resto", Location = "Test Location", Phone = "123", OwnerUserId = "user1" };
            var result = await _service.CreateRestaurantAsync(restaurant);
            await _context.Entry(restaurant).ReloadAsync();
            Assert.IsTrue(result);
            Assert.That(await _context.Restaurants.CountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetRestaurantByOwnerIdAsync_ReturnsCorrectRestaurant()
        {
            var restaurant = new Restaurant { Name = "Test Resto", Location = "Loc", Phone = "123", OwnerUserId = "user2" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            _context.Entry(restaurant).State = EntityState.Detached;

            var result = await _service.GetRestaurantByOwnerIdAsync("user2");
            Assert.That(result?.Name, Is.EqualTo("Test Resto"));
        }

        [Test]
        public async Task GetRestaurantByOwnerIdAsync_ReturnsNullIfNotFound()
        {
            var result = await _service.GetRestaurantByOwnerIdAsync("missing");
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddFoodAsync_AddsFoodWithNewCategory()
        {
            var restaurant = new Restaurant { Name = "R", Location = "L", Phone = "P", OwnerUserId = "user3" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Pizza", Price = 10.0m, Description = "Desc", ImageUrl = "url" };
            var result = await _service.AddFoodAsync("user3", food, new List<string> { "Italian" });

            await _context.Entry(food).ReloadAsync();

            Assert.IsTrue(result);
            Assert.That(await _context.Foods.CountAsync(), Is.EqualTo(1));
            Assert.That(await _context.Categories.CountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task AddFoodAsync_ReturnsFalseIfRestaurantNotFound()
        {
            var food = new Food { Name = "Burger", Description = "D", ImageUrl = "U" };
            var result = await _service.AddFoodAsync("missing", food, new List<string> { "FastFood" });
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddFoodAsync_UsesExistingCategory()
        {
            var category = new Category { CategoryName = "Shared" };
            await _context.Categories.AddAsync(category);
            var restaurant = new Restaurant { Name = "R", Location = "L", Phone = "P", OwnerUserId = "user4" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Taco", Description = "D", ImageUrl = "U" };
            var result = await _service.AddFoodAsync("user4", food, new List<string> { "Shared" });

            Assert.IsTrue(result);
            Assert.That(await _context.Categories.CountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteFoodAsync_RemovesFood()
        {
            var food = new Food { Name = "ToDelete", Description = "D", ImageUrl = "U" };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var result = await _service.DeleteFoodAsync(food.FoodId);
            Assert.IsTrue(result);
            Assert.That(await _context.Foods.CountAsync(), Is.EqualTo(0));
        }

        [Test]
        public async Task DeleteFoodAsync_ReturnsFalseIfNotFound()
        {
            var result = await _service.DeleteFoodAsync(999);
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddFoodAsync_AssignsFoodToCorrectRestaurant()
        {
            var restaurant = new Restaurant { Name = "R", Location = "L", Phone = "P", OwnerUserId = "user5" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Soup", Description = "D", ImageUrl = "U" };
            await _service.AddFoodAsync("user5", food, new List<string> { "Warm" });

            var addedFood = await _context.Foods.FirstOrDefaultAsync();
            Assert.That(addedFood.RestaurantId, Is.EqualTo(restaurant.RestaurantId));
        }

        [Test]
        public async Task AddFoodAsync_CreatesCorrectFoodCategoryRelations()
        {
            var restaurant = new Restaurant { Name = "R", Location = "L", Phone = "P", OwnerUserId = "user6" };
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            var food = new Food { Name = "Steak", Description = "D", ImageUrl = "U" };
            await _service.AddFoodAsync("user6", food, new List<string> { "Meat", "Dinner" });

            var foodEntity = await _context.Foods.Include(f => f.FoodCategories).FirstOrDefaultAsync();
            await _context.Entry(foodEntity).Collection(f => f.FoodCategories).LoadAsync();
            Assert.That(foodEntity?.FoodCategories.Count, Is.EqualTo(2));
        }
    }
}
