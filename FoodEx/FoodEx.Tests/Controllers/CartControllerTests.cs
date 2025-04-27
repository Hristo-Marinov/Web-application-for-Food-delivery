using FoodEx.Controllers;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class CartControllerTests
    {
        private Mock<ICartService> _cartServiceMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private CartController _controller;

        [SetUp]
        public void Setup()
        {
            _cartServiceMock = new Mock<ICartService>();

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            _controller = new CartController(_cartServiceMock.Object, _userManagerMock.Object);
        }

        private void SetupUser(string userId)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            _userManagerMock.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(userId);
        }

        [Test]
        public async Task Index_ReturnsViewWithModel()
        {
            var expectedModel = new CartViewModel();
            _cartServiceMock.Setup(s => s.GetCartViewModelAsync("user123")).ReturnsAsync(expectedModel);
            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("user123");

            var result = await _controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(expectedModel));
        }

        [Test]
        public async Task AddToCart_RedirectsToIndex()
        {
            SetupUser("user1");

            var result = await _controller.AddToCart(1);

            _cartServiceMock.Verify(x => x.AddToCartAsync("user1", 1), Times.Once);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task RemoveFromCart_RedirectsToIndex()
        {
            var result = await _controller.RemoveFromCart(1);

            _cartServiceMock.Verify(x => x.RemoveFromCartAsync(1), Times.Once);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [Test]
        public async Task Checkout_RedirectsToCheckoutIndex()
        {
            var result = await _controller.Checkout();

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual("Checkout", redirectResult.ControllerName);
        }
    }
}
