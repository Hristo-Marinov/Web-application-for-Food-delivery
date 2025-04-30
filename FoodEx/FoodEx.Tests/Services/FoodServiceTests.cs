using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FoodEx.Data.Context;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class FoodServiceTests
    {
        private ApplicationDbContext _context;
        private FoodService _foodService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "FoodServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _foodService = new FoodService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetFoodDetailsAsync_ReturnsCorrectDetails()
        {
            var restaurant = new Restaurant { Name = "Test Restaurant", Location = "Test Location", Phone = "123456789", OwnerUserId = "owner-id" };
            var food = new Food { FoodId = 1, Name = "Pizza", Description = "Tasty", Price = 12.99m, ImageUrl = "test.jpg", Restaurant = restaurant };
            var rating = new Rating { FoodId = 1, UserId = "user1", RatingValue = 5, Comment = "Excellent!" };

            await _context.Foods.AddAsync(food);
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            var result = await _foodService.GetFoodDetailsAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pizza", result.Name);
            Assert.AreEqual(5, result.AverageRating);
            Assert.AreEqual(1, result.Comments.Count);
        }

        [Test]
        public async Task AddToCartAsync_AddsItemToCart()
        {
            var food = new Food { FoodId = 1, Name = "Pizza", Description = "Tasty", Price = 12.99m, ImageUrl = "test.jpg", Restaurant = new Restaurant { Name = "Test Restaurant", Location = "Test Location", Phone = "123456789", OwnerUserId = "owner-id" } };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var userId = "user1";

            await _foodService.AddToCartAsync(userId, 1);

            var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);

            Assert.IsNotNull(cart);
            Assert.AreEqual(1, cart.Items.Count);
            Assert.AreEqual(1, cart.Items.First().FoodId);
        }

        [Test]
        public async Task SubmitRatingAsync_AddsNewRating()
        {
            var food = new Food { FoodId = 1, Name = "Pizza", Description = "Tasty", Price = 12.99m, ImageUrl = "test.jpg", Restaurant = new Restaurant { Name = "Test Restaurant", Location = "Test Location", Phone = "123456789", OwnerUserId = "owner-id" } };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var userId = "user1";

            await _foodService.SubmitRatingAsync(1, userId, 5, "Awesome!");

            var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.FoodId == 1 && r.UserId == userId);

            Assert.IsNotNull(rating);
            Assert.AreEqual(5, rating.RatingValue);
            Assert.AreEqual("Awesome!", rating.Comment);
        }

        [Test]
        public async Task SubmitRatingAsync_UpdatesExistingRating()
        {
            var food = new Food { FoodId = 1, Name = "Pizza", Description = "Tasty", Price = 12.99m, ImageUrl = "test.jpg", Restaurant = new Restaurant { Name = "Test Restaurant", Location = "Test Location", Phone = "123456789", OwnerUserId = "owner-id" } };
            var rating = new Rating { FoodId = 1, UserId = "user1", RatingValue = 4, Comment = "Good" };

            await _context.Foods.AddAsync(food);
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            await _foodService.SubmitRatingAsync(1, "user1", 5, "Excellent!");

            var updatedRating = await _context.Ratings.FirstOrDefaultAsync(r => r.FoodId == 1 && r.UserId == "user1");

            Assert.IsNotNull(updatedRating);
            Assert.AreEqual(5, updatedRating.RatingValue);
            Assert.AreEqual("Excellent!", updatedRating.Comment);
        }
    }
}
