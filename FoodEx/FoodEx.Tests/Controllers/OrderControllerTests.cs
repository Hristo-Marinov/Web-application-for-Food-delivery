using FoodEx.Controllers;
using FoodEx.Data;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Models;
using FoodEx.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IOrderService> _orderServiceMock;
        private Mock<IDeliveryService> _deliveryServiceMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private OrdersController _controller;
        private ApplicationUser _mockUser;

        [SetUp]
        public void Setup()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _deliveryServiceMock = new Mock<IDeliveryService>();

            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

            _controller = new OrdersController(_orderServiceMock.Object, _deliveryServiceMock.Object, _userManagerMock.Object);

            _mockUser = new ApplicationUser { Id = "user123", Email = "test@foodex.com" };
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, _mockUser.Id)
            }));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [Test]
        public async Task UserOrders_ReturnsViewWithOrders()
        {
            var orders = new List<Order> { new Order { OrderId = 1 } };
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(_mockUser.Id);
            _orderServiceMock.Setup(s => s.GetUserOrdersAsync(_mockUser.Id)).ReturnsAsync(orders);

            var result = await _controller.UserOrders() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("UserOrders"));
            Assert.That(result.Model, Is.EqualTo(orders));
        }

        [Test]
        public async Task RestaurantPanel_ReturnsViewWithOrders()
        {
            var orders = new List<Order> { new Order { OrderId = 2 } };
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(_mockUser.Id);
            _orderServiceMock.Setup(s => s.GetRestaurantOrdersAsync(_mockUser.Id)).ReturnsAsync(orders);

            var result = await _controller.RestaurantPanel() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("RestaurantPanel"));
            Assert.That(result.Model, Is.EqualTo(orders));
        }

        [Test]
        public async Task DeliveryPanel_ReturnsViewWithModel()
        {
            _mockUser.LockoutEnabled = false;

            var available = new List<Order> { new Order { OrderId = 3 } };
            var myOrders = new List<Order> { new Order { OrderId = 4 } };

            _userManagerMock.Setup(m => m.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(_mockUser);
            _deliveryServiceMock.Setup(d => d.GetAvailableOrdersAsync()).ReturnsAsync(available);
            _deliveryServiceMock.Setup(d => d.GetMyOrdersAsync(_mockUser.Id)).ReturnsAsync(myOrders);

            var result = await _controller.DeliveryPanel() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("DeliveryPanel"));
            var model = result.Model as DeliveryPanelViewModel;
            Assert.That(model.AvailableOrders.Count, Is.EqualTo(1));
            Assert.That(model.MyOrders.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateOrderStatusByRestaurant_Success_ReturnsRedirect()
        {
            _orderServiceMock.Setup(s => s.UpdateOrderStatusByRestaurantAsync(1, OrderStatus.Prepared)).ReturnsAsync(true);

            var result = await _controller.UpdateOrderStatusByRestaurant(1, OrderStatus.Prepared) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("RestaurantPanel"));
        }

        [Test]
        public async Task UpdateOrderStatusByDelivery_Success_ReturnsRedirect()
        {
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(_mockUser.Id);
            _orderServiceMock.Setup(s => s.UpdateOrderStatusByDeliveryAsync(1, OrderStatus.Delivered, _mockUser.Id)).ReturnsAsync(true);

            var result = await _controller.UpdateOrderStatusByDelivery(1, OrderStatus.Delivered) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("DeliveryPanel"));
        }

        [Test]
        public async Task ClaimOrder_ReturnsRedirect()
        {
            _userManagerMock.Setup(m => m.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(_mockUser.Id);
            _deliveryServiceMock.Setup(d => d.ClaimOrderAsync(1, _mockUser.Id)).ReturnsAsync(true);

            var result = await _controller.ClaimOrder(1) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("DeliveryPanel"));
        }
    }
}
