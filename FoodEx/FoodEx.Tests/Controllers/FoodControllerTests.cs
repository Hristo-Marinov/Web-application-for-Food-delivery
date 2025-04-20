using FoodEx.Controllers;
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
    public class FoodControllerTests
    {
        private Mock<IFoodService> _foodServiceMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private FoodController _controller;

        [SetUp]
        public void SetUp()
        {
            _foodServiceMock = new Mock<IFoodService>();

            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStore.Object, null, null, null, null, null, null, null, null
            );

            _controller = new FoodController(_foodServiceMock.Object, _userManagerMock.Object);
        }

        [Test]
        public async Task FoodDetails_ReturnsView_WhenFoodExists()
        {
            var foodId = 1;
            var viewModel = new FoodViewModel { FoodId = foodId };
            _foodServiceMock.Setup(s => s.GetFoodDetailsAsync(foodId)).ReturnsAsync(viewModel);

            var result = await _controller.FoodDetails(foodId) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(viewModel));
        }

        [Test]
        public async Task FoodDetails_ReturnsNotFound_WhenFoodDoesNotExist()
        {
            _foodServiceMock.Setup(s => s.GetFoodDetailsAsync(It.IsAny<int>())).ReturnsAsync((FoodViewModel)null);

            var result = await _controller.FoodDetails(999);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task OrderNow_RedirectsToCartIndex()
        {
            var userId = "user1";
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .Returns(userId);

            var result = await _controller.OrderNow(1) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("Index"));
            Assert.That(result.ControllerName, Is.EqualTo("Cart"));
            _foodServiceMock.Verify(s => s.AddToCartAsync(userId, 1), Times.Once);
        }

        [Test]
        public async Task SubmitRating_SubmitsAndRedirects()
        {
            var user = new ApplicationUser { Id = "user1" };
            _userManagerMock.Setup(m => m.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync(user);

            var result = await _controller.SubmitRating(2, 5, "Great!") as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("FoodDetails"));
            Assert.That(result.RouteValues["id"], Is.EqualTo(2));
            _foodServiceMock.Verify(s => s.SubmitRatingAsync(2, user.Id, 5, "Great!"), Times.Once);
        }
    }
}
