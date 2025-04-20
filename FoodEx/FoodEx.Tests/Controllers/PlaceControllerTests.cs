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
    public class PlaceControllerTests
    {
        private Mock<IPlaceService> _placeServiceMock;
        private PlaceController _controller;

        [SetUp]
        public void Setup()
        {
            _placeServiceMock = new Mock<IPlaceService>();
            _controller = new PlaceController(_placeServiceMock.Object);
        }

        [Test]
        public async Task PlaceDetails_ValidId_ReturnsView()
        {
            var restaurant = new Restaurant { RestaurantId = 1, Name = "Test", Foods = new List<Food>() };

            _placeServiceMock.Setup(s => s.GetRestaurantWithFoodsAsync(1)).ReturnsAsync(restaurant);

            var result = await _controller.PlaceDetails(1) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("PlaceDetails"));
            Assert.That(result.Model, Is.EqualTo(restaurant));
        }

        [Test]
        public async Task PlaceDetails_InvalidId_ReturnsNotFound()
        {
            _placeServiceMock.Setup(s => s.GetRestaurantWithFoodsAsync(99)).ReturnsAsync((Restaurant)null);

            var result = await _controller.PlaceDetails(99);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task FoodDetails_ValidId_ReturnsView()
        {
            var food = new Food
            {
                FoodId = 1,
                Name = "Burger",
                Description = "Juicy",
                Price = 5.99m,
                Restaurant = new Restaurant { Name = "Grill House" }
            };

            _placeServiceMock.Setup(s => s.GetFoodWithRestaurantAsync(1)).ReturnsAsync(food);

            var result = await _controller.FoodDetails(1) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("FoodDetails"));
        }

        [Test]
        public async Task FoodDetails_InvalidId_ReturnsNotFound()
        {
            _placeServiceMock.Setup(s => s.GetFoodWithRestaurantAsync(42)).ReturnsAsync((Food)null);

            var result = await _controller.FoodDetails(42);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Place_NoSearchTerm_ReturnsAllRestaurants()
        {
            var restaurants = new List<Restaurant> { new Restaurant { Name = "A" }, new Restaurant { Name = "B" } };

            _placeServiceMock.Setup(s => s.GetRestaurantsAsync(null)).ReturnsAsync(restaurants);

            var result = await _controller.Place(null) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.Null); 
            Assert.That(result.Model, Is.EqualTo(restaurants));
        }

        [Test]
        public async Task Place_WithSearchTerm_ReturnsFilteredRestaurants()
        {
            var restaurants = new List<Restaurant> { new Restaurant { Name = "Pizza Place" } };

            _placeServiceMock.Setup(s => s.GetRestaurantsAsync("Pizza")).ReturnsAsync(restaurants);

            var result = await _controller.Place("Pizza") as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(restaurants));
            Assert.That(result.ViewData["SearchTerm"], Is.EqualTo("Pizza"));
        }
    }
}
