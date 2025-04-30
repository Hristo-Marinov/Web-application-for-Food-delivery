using FoodEx.Data.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Tests.Services
{
    [TestFixture]
    public class CartServiceTests
    {
        private ApplicationDbContext _context;
        private CartService _cartService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CartServiceTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _cartService = new CartService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private Food CreateValidFood(int id, string name)
        {
            return new Food
            {
                FoodId = id,
                Name = name,
                Price = 10,
                Description = "Description",
                ImageUrl = "ImageUrl"
            };
        }

        [Test]
        public async Task AddToCartAsync_AddsItemToCart()
        {
            var userId = "user1";
            var food = CreateValidFood(1, "Pizza");
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            await _cartService.AddToCartAsync(userId, 1);

            var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
            Assert.NotNull(cart);
            Assert.AreEqual(1, cart.Items.Count);
            Assert.AreEqual(1, cart.Items.First().Quantity);
        }

        [Test]
        public async Task RemoveFromCartAsync_RemovesItem()
        {
            var userId = "user1";
            var food = CreateValidFood(1, "Burger");
            await _context.Foods.AddAsync(food);
            var cart = new Cart { UserId = userId };
            cart.Items.Add(new CartItem { FoodId = 1, Quantity = 1 });
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            var cartItemId = cart.Items.First().CartItemId;

            await _cartService.RemoveFromCartAsync(cartItemId);

            var deletedItem = await _context.CartItems.FindAsync(cartItemId);
            Assert.Null(deletedItem);
        }

        [Test]
        public async Task GetCartViewModelAsync_ReturnsCorrectItems()
        {
            var userId = "user1";
            var food = CreateValidFood(1, "Sushi");
            await _context.Foods.AddAsync(food);
            var cart = new Cart { UserId = userId };
            cart.Items.Add(new CartItem { FoodId = 1, Quantity = 2 });
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            var model = await _cartService.GetCartViewModelAsync(userId);

            Assert.AreEqual(1, model.Items.Count);
            Assert.AreEqual("Sushi", model.Items.First().FoodName);
            Assert.AreEqual(2, model.Items.First().Quantity);
        }

        [Test]
        public async Task CheckoutAsync_WithExistingAddress_CreatesOrder()
        {
            var userId = "user1";
            var food = CreateValidFood(1, "Pasta");
            await _context.Foods.AddAsync(food);
            await _context.Carts.AddAsync(new Cart { UserId = userId, Items = { new CartItem { FoodId = 1, Quantity = 1 } } });
            await _context.Addresses.AddAsync(new Address { UserId = userId, Street = "Test St", City = "Test City", Country = "Test Country", PostalCode = "12345" });
            await _context.SaveChangesAsync();

            var result = await _cartService.CheckoutAsync(userId);

            Assert.IsTrue(result);
            Assert.AreEqual(1, await _context.Orders.CountAsync());
        }
    }
}
