using FoodEx.Controllers;
using FoodEx.Data.Context;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
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
    public class RestaurantControllerTests
    {
        private Mock<IRestaurantService> _restaurantServiceMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<ApplicationDbContext> _contextMock;
        private RestaurantController _controller;

        [SetUp]
        public void Setup()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            _restaurantServiceMock = new Mock<IRestaurantService>();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            _contextMock = new Mock<ApplicationDbContext>(options);

            _controller = new RestaurantController(_restaurantServiceMock.Object, _userManagerMock.Object, _contextMock.Object);
        }

        [Test]
        public async Task MyRestaurant_ReturnsViewWithRestaurant()
        {
            var userId = "user-123";
            var restaurant = new Restaurant { Name = "Testaurant" };

            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns(userId);
            _restaurantServiceMock.Setup(s => s.GetRestaurantByOwnerIdAsync(userId)).ReturnsAsync(restaurant);

            var result = await _controller.MyRestaurant() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(restaurant));
        }

        [Test]
        public async Task CreateRestaurant_Post_InvalidUser_ReturnsViewWithError()
        {
            var user = new ApplicationUser { LockoutEnabled = true };
            _userManagerMock.Setup(u => u.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).ReturnsAsync(user);

            var model = new Restaurant();
            var result = await _controller.CreateRestaurant(model) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(_controller.ModelState.IsValid, Is.False);
        }

        [Test]
        public async Task CreateRestaurant_Post_Valid_ReturnsRedirect()
        {
            var user = new ApplicationUser { Id = "user-456", LockoutEnabled = false };
            _userManagerMock.Setup(u => u.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).ReturnsAsync(user);
            _restaurantServiceMock.Setup(s => s.CreateRestaurantAsync(It.IsAny<Restaurant>())).ReturnsAsync(true);

            var model = new Restaurant { Name = "Resto", Location = "Loc", Phone = "123" };
            var result = await _controller.CreateRestaurant(model) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("MyRestaurant"));
        }

        [Test]
        public async Task AddFood_Post_InvalidModel_ReturnsViewWithError()
        {
            var viewModel = new FoodViewModel();
            var result = await _controller.AddFood(viewModel, new List<int>()) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(_controller.ModelState.IsValid, Is.False);
        }

        [Test]
        public async Task DeleteFood_CallsServiceAndRedirects()
        {
            var result = await _controller.DeleteFood(1) as RedirectToActionResult;

            _restaurantServiceMock.Verify(s => s.DeleteFoodAsync(1), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("MyRestaurant"));
        }
    }
}