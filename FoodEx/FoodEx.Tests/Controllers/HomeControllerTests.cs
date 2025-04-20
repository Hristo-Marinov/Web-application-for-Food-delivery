using FoodEx.Controllers;
using FoodEx.Data.Entity;
using FoodEx.Entity;
using FoodEx.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<IHomeService> _homeServiceMock;
        private HomeController _controller;

        [SetUp]
        public void SetUp()
        {
            _homeServiceMock = new Mock<IHomeService>();
            _controller = new HomeController(_homeServiceMock.Object);
        }

        [Test]
        public async Task Index_ReturnsViewWithRestaurantsAndCounts()
        {
            var restaurantList = new List<Restaurant> { new Restaurant { Name = "Testaurant" } };

            _homeServiceMock.Setup(s => s.GetRestaurantCountAsync()).ReturnsAsync(5);
            _homeServiceMock.Setup(s => s.GetFoodCountAsync()).ReturnsAsync(10);
            _homeServiceMock.Setup(s => s.GetDeliveryGuyCountAsync()).ReturnsAsync(3);
            _homeServiceMock.Setup(s => s.GetAllRestaurantsAsync()).ReturnsAsync(restaurantList);

            var result = await _controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(restaurantList));
            Assert.That(_controller.ViewBag.RestaurantCount, Is.EqualTo(5));
            Assert.That(_controller.ViewBag.FoodCount, Is.EqualTo(10));
            Assert.That(_controller.ViewBag.DeliveryGuyCount, Is.EqualTo(3));
        }

        [Test]
        public async Task Place_ReturnsViewWithRestaurants()
        {
            var restaurants = new List<Restaurant> { new Restaurant { Name = "Pizza Place" } };
            _homeServiceMock.Setup(s => s.GetAllRestaurantsAsync()).ReturnsAsync(restaurants);

            var result = await _controller.Place() as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(restaurants));
        }
    }
}
