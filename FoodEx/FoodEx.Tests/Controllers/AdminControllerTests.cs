using FoodEx.Controllers;
using FoodEx.Data.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class AdminControllerTests
    {
        private ApplicationDbContext _context;
        private AdminController _controller;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AdminService _adminService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AdminControllerTestDb")
                .Options;

            _context = new ApplicationDbContext(options);

            var userStore = new UserStore<ApplicationUser>(_context);
            _userManager = new UserManager<ApplicationUser>(
                userStore, null, new PasswordHasher<ApplicationUser>(),
                new List<IUserValidator<ApplicationUser>>(), new List<IPasswordValidator<ApplicationUser>>(),
                new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), null, null);

            var roleStore = new RoleStore<IdentityRole>(_context);
            _roleManager = new RoleManager<IdentityRole>(
                roleStore, new List<IRoleValidator<IdentityRole>>(), new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), null);

            _adminService = new AdminService(_context);

            _controller = new AdminController(_userManager, _roleManager, _context, _adminService);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task AdminPanel_ReturnsViewResult_WithUserRoles()
        {
            // Arrange
            var adminRole = new IdentityRole("Admin");
            await _roleManager.CreateAsync(adminRole);

            var user = new ApplicationUser { UserName = "adminuser", Email = "admin@example.com" };
            await _userManager.CreateAsync(user, "Admin123!");
            await _userManager.AddToRoleAsync(user, "Admin");

            // Act
            var result = await _controller.AdminPanel();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var model = ((ViewResult)result).Model as List<(ApplicationUser User, string Role)>;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Count);
            Assert.AreEqual("Admin", model.First().Role);
        }

        [Test]
        public async Task DeleteRating_RatingExists_DeletesRating()
        {
            // Arrange
            var user = new ApplicationUser { UserName = "testuser", Email = "test@example.com" };
            await _userManager.CreateAsync(user, "Test123!");

            var food = new Food
            {
                Name = "Pizza",
                //Category = "Italian",
                Description = "Delicious pizza",
                Price = 12.5m,
                ImageUrl = "pizza.jpg",
                RestaurantId = 1
            };
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            var rating = new Rating
            {
                FoodId = food.FoodId,
                UserId = user.Id,
                RatingValue = 5,
                Comment = "Amazing!"
            };
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteRating(rating.RatingId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var ratingInDb = await _context.Ratings.FindAsync(rating.RatingId);
            Assert.IsNull(ratingInDb);
        }
    }
}
