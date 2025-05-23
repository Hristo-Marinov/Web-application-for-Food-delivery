﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using FoodEx.Controllers;
using FoodEx.Data.Entity;
using FoodEx.Services;
using FoodEx.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class PlaceControllerTests
    {
        private Mock<IPlaceService> _placeServiceMock;
        private PlaceController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Mock the IPlaceService
            _placeServiceMock = new Mock<IPlaceService>();

            // Set up InMemory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            _context = new ApplicationDbContext(options);

            // Initialize the controller with the mocked IPlaceService and the InMemory database context
            _controller = new PlaceController(_placeServiceMock.Object, _context);
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
        public async Task Place_WithEmptySearchTerm_ReturnsAllRestaurants()
        {
            // Arrange
            var restaurants = new List<Restaurant>
            {
                new Restaurant { Name = "Pizza Place", Location = "Location 1" },
                new Restaurant { Name = "Burger Place", Location = "Location 2" }
            };
            _placeServiceMock.Setup(s => s.GetRestaurantsAsync(null))
                .ReturnsAsync(restaurants);

            // Act
            var result = await _controller.Place(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as List<Restaurant>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
        }
    }
}