
using FoodEx.Controllers;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class CheckoutControllerTests
    {
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<ICartService> _cartServiceMock;
        private CheckoutController _controller;

        [SetUp]
        public void Setup()
        {
            _cartServiceMock = new Mock<ICartService>();

            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                store.Object, null, null, null, null, null, null, null, null
            );

            _controller = new CheckoutController(_userManagerMock.Object, _cartServiceMock.Object);

            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            _controller.TempData = tempData;
        }

        [Test]
        public void Index_Get_ReturnsView()
        {
            var result = _controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_Post_InvalidModel_ReturnsViewWithModel()
        {
            var model = new CheckoutViewModel();
            _controller.ModelState.AddModelError("Street", "Required");

            var result = _controller.Index(model) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(model, result.Model);
        }

        [Test]
        public void Index_Post_ValidModel_RedirectsToSubmit()
        {
            var model = new CheckoutViewModel { Street = "Test Street" };
            var result = _controller.Index(model) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Submit", result.ActionName);
        }

        [Test]
        public async Task Submit_Post_SuccessfulCheckout_RedirectsToUserOrders()
        {
            var model = new CheckoutViewModel { Street = "Test Street" };
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("test-user-id");
            _cartServiceMock.Setup(c => c.CheckoutAsync("test-user-id", model)).ReturnsAsync(true);

            var result = await _controller.Submit(model) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("UserOrders", result.ActionName);
            Assert.AreEqual("Orders", result.ControllerName);
        }

        [Test]
        public async Task Submit_Post_FailedCheckout_ReturnsIndexView()
        {
            var model = new CheckoutViewModel { Street = "Test Street" };
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("test-user-id");
            _cartServiceMock.Setup(c => c.CheckoutAsync("test-user-id", model)).ReturnsAsync(false);

            var result = await _controller.Submit(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(model, result.Model);
        }

        [Test]
        public void ConfirmAddress_Post_InvalidModel_ReturnsIndex()
        {
            var model = new CheckoutViewModel();
            _controller.ModelState.AddModelError("Street", "Required");

            var result = _controller.ConfirmAddress(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void ConfirmAddress_Post_ValidModel_ReturnsConfirmView()
        {
            var model = new CheckoutViewModel { Street = "Valid Street" };
            var result = _controller.ConfirmAddress(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("ConfirmAddress", result.ViewName);
            Assert.AreEqual(model, result.Model);
        }

        [Test]
        public async Task SubmitConfirmed_Post_SuccessfulCheckout_Redirects()
        {
            var model = new CheckoutViewModel { Street = "Final Street" };
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("test-user-id");
            _cartServiceMock.Setup(c => c.CheckoutAsync("test-user-id", model)).ReturnsAsync(true);

            var result = await _controller.SubmitConfirmed(model) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("UserOrders", result.ActionName);
            Assert.AreEqual("Orders", result.ControllerName);
        }

        [Test]
        public async Task SubmitConfirmed_Post_FailedCheckout_ReturnsConfirmAddress()
        {
            var model = new CheckoutViewModel { Street = "Final Street" };
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("test-user-id");
            _cartServiceMock.Setup(c => c.CheckoutAsync("test-user-id", model)).ReturnsAsync(false);

            var result = await _controller.SubmitConfirmed(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("ConfirmAddress", result.ViewName);
            Assert.AreEqual(model, result.Model);
        }
    }
}
