using FoodEx.Controllers;
using FoodEx.Data;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;  // Add this for IConfiguration

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IOrderService> _mockOrderService;
        private Mock<IDeliveryService> _mockDeliveryService;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<IConfiguration> _mockConfiguration;  // Add this mock
        private Mock<IEmailSender> _mockEmailSender;      // Add this mock
        private OrdersController _controller;

        [SetUp]
        public void Setup()
        {
            _mockOrderService = new Mock<IOrderService>();
            _mockDeliveryService = new Mock<IDeliveryService>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            _mockConfiguration = new Mock<IConfiguration>();  // Initialize the mock for IConfiguration
            _mockEmailSender = new Mock<IEmailSender>();      // Initialize the mock for IEmailSender

            _controller = new OrdersController(_mockOrderService.Object, _mockDeliveryService.Object, _mockUserManager.Object, _mockConfiguration.Object, _mockEmailSender.Object);  // Inject mocks into the controller
        }

        [Test]
        public async Task UserOrders_ReturnsViewWithOrders()
        {
            var userId = "user1";
            _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(userId);
            _mockOrderService.Setup(x => x.GetUserOrdersAsync(userId)).ReturnsAsync(new List<Order>());

            var result = await _controller.UserOrders() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("UserOrders", result.ViewName);
        }

        [Test]
        public async Task RestaurantPanel_ReturnsOrdersView()
        {
            var userId = "restUser";
            _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(userId);
            _mockOrderService.Setup(x => x.GetRestaurantOrdersAsync(userId)).ReturnsAsync(new List<Order>());

            var result = await _controller.RestaurantPanel() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("RestaurantPanel", result.ViewName);
        }

        [Test]
        public async Task PreviousOrders_ReturnsDeliveredOrders()
        {
            var userId = "user123";
            _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(userId);
            _mockOrderService.Setup(x => x.GetUserDeliveredOrdersAsync(userId)).ReturnsAsync(new List<Order>());

            var result = await _controller.PreviousOrders() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("PreviousOrders", result.ViewName);
        }

        [Test]
        public void StaffOverview_ReturnsView()
        {
            var result = _controller.StaffOverview() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("StaffOverview", result.ViewName);
        }

        [Test]
        public void UserOverview_ReturnsView()
        {
            var result = _controller.UserOverview() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("UserOverview", result.ViewName);
        }

    }
}
