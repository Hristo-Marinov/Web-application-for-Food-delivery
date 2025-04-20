using FoodEx.Controllers;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class RestaurantControllerTests
    {
        private Mock<IRestaurantService> _restaurantServiceMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private RestaurantController _controller;

        [SetUp]
        public void Setup()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            _restaurantServiceMock = new Mock<IRestaurantService>();
            _controller = new RestaurantController(_restaurantServiceMock.Object, _userManagerMock.Object);
        }

        [Test]
        public async Task MyRestaurant_ReturnsRestaurantView()
        {
            var userId = "user-id";
            var restaurant = new Restaurant { Name = "Test" };

            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns(userId);
            _restaurantServiceMock.Setup(s => s.GetRestaurantByOwnerIdAsync(userId)).ReturnsAsync(restaurant);

            var result = await _controller.MyRestaurant() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(restaurant));
        }

        [Test]
        public void CreateRestaurant_Get_ReturnsView()
        {
            var result = _controller.CreateRestaurant() as ViewResult;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task CreateRestaurant_Post_UnverifiedUser_ReturnsError()
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
            var user = new ApplicationUser { Id = "123", LockoutEnabled = false };
            _userManagerMock.Setup(u => u.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).ReturnsAsync(user);
            _restaurantServiceMock.Setup(s => s.CreateRestaurantAsync(It.IsAny<Restaurant>())).ReturnsAsync(true);

            var model = new Restaurant { Name = "New", Location = "Here", Phone = "000" };
            var result = await _controller.CreateRestaurant(model) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("MyRestaurant"));
        }

        [Test]
        public async Task AddFood_Valid_ReturnsRedirect()
        {
            var userId = "123";
            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns(userId);
            _restaurantServiceMock.Setup(s => s.AddFoodAsync(userId, It.IsAny<Food>())).ReturnsAsync(true);

            var result = await _controller.AddFood(new Food()) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("MyRestaurant"));
        }

        [Test]
        public async Task AddFood_Failure_ReturnsViewWithModel()
        {
            var userId = "123";
            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns(userId);
            _restaurantServiceMock.Setup(s => s.AddFoodAsync(userId, It.IsAny<Food>())).ReturnsAsync(false);

            var food = new Food { Name = "Fail" };
            var result = await _controller.AddFood(food) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(food));
        }

        [Test]
        public async Task DeleteFood_Valid_Redirects()
        {
            var result = await _controller.DeleteFood(1) as RedirectToActionResult;

            _restaurantServiceMock.Verify(s => s.DeleteFoodAsync(1), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("MyRestaurant"));
        }
    }
}
