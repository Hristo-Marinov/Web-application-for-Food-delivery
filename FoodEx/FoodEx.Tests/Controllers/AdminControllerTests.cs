using FoodEx.Controllers;
using FoodEx.Data.Entity.Context;
using FoodEx.Entity;
using Microsoft.AspNetCore.Identity;
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
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private ApplicationDbContext _context;
        private AdminController _controller;

        [SetUp]
        public void Setup()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStore.Object, null, null, null, null, null, null, null, null
            );

            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                roleStore.Object, null, null, null, null
            );

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AdminControllerTestsDb")
                .Options;
            _context = new ApplicationDbContext(options);

            _controller = new AdminController(_userManagerMock.Object, _roleManagerMock.Object, _context);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        

        [Test]
        public async Task ToggleVerification_FlipsLockoutEnabled_AndRedirects()
        {
            var user = new ApplicationUser { Id = "1", LockoutEnabled = true };
            _userManagerMock.Setup(m => m.FindByIdAsync("1")).ReturnsAsync(user);
            _userManagerMock.Setup(m => m.UpdateAsync(user)).ReturnsAsync(IdentityResult.Success);

            var result = await _controller.ToggleVerification("1") as RedirectToActionResult;

            Assert.That(user.LockoutEnabled, Is.False);
            Assert.That(result.ActionName, Is.EqualTo("AdminPanel"));
        }

        [Test]
        public async Task UpdateOrderStatus_ChangesStatus_AndRedirects()
        {
            var order = new FoodEx.Data.Entity.Order
            {
                OrderId = 1,
                Status = FoodEx.Data.OrderStatus.Pending
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var result = await _controller.UpdateOrderStatus(1, FoodEx.Data.OrderStatus.Delivered) as RedirectToActionResult;

            var updatedOrder = await _context.Orders.FindAsync(1);
            Assert.That(updatedOrder.Status, Is.EqualTo(FoodEx.Data.OrderStatus.Delivered));
            Assert.That(result.ActionName, Is.EqualTo("AdminPanel"));
        }
    }

    public static class TestHelpers
    {
        public static Mock<DbSet<T>> BuildMockDbSet<T>(this IQueryable<T> source) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(source.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(source.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(source.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(source.GetEnumerator());
            return mockSet;
        }
    }
}
