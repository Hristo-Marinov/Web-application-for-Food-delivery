using FoodEx.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class ErrorControllerTests
    {
        [Test]
        public void StatusCodeHandler_ReturnsStatusView_WithCorrectStatusCode()
        {
            var controller = new ErrorController();
            var result = controller.StatusCodeHandler(404) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("Status"));
            Assert.That(controller.ViewData["StatusCode"], Is.EqualTo(404));
        }

        [Test]
        public void ExceptionHandler_ReturnsExceptionView_WithErrorDetails()
        {
            // Arrange
            var controller = new ErrorController();
            var context = new DefaultHttpContext();

            var feature = new Mock<IExceptionHandlerPathFeature>();
            feature.Setup(f => f.Error).Returns(new Exception("Test error"));
            feature.Setup(f => f.Path).Returns("/test/path");

            context.Features.Set<IExceptionHandlerPathFeature>(feature.Object);
            controller.ControllerContext.HttpContext = context;

            // Act
            var result = controller.ExceptionHandler() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("Exception"));
            Assert.That(controller.ViewData["ErrorMessage"], Is.EqualTo("Test error"));
            Assert.That(controller.ViewData["Path"], Is.EqualTo("/test/path"));
        }
    }
}
