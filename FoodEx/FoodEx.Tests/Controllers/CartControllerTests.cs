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
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            _controller = new CartController(_cartServiceMock.Object, _userManagerMock.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user123")
            }, "mock"));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
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
            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("user123");

            var result = await _controller.AddToCart(1) as RedirectToActionResult;

            _cartServiceMock.Verify(s => s.AddToCartAsync("user123", 1), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task RemoveFromCart_RedirectsToIndex()
        {
            var result = await _controller.RemoveFromCart(10) as RedirectToActionResult;

            _cartServiceMock.Verify(s => s.RemoveFromCartAsync(10), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Checkout_RedirectsToUserOrders()
        {
            _userManagerMock.Setup(u => u.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("user123");
            _cartServiceMock.Setup(s => s.CheckoutAsync("user123")).ReturnsAsync(true);

            var result = await _controller.Checkout() as RedirectToActionResult;

            Assert.That(result.ControllerName, Is.EqualTo("Orders"));
            Assert.That(result.ActionName, Is.EqualTo("UserOrders"));
        }
    }
}
