using FoodEx.Controllers;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodEx.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private AccountController _controller;

        [SetUp]
        public void Setup()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var contextAccessor = new Mock<Microsoft.AspNetCore.Http.IHttpContextAccessor>();
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object,
                contextAccessor.Object,
                claimsFactory.Object,
                null,
                null,
                null,
                null);

            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStore.Object, null, null, null, null);

            _controller = new AccountController(
                _userManagerMock.Object,
                _signInManagerMock.Object,
                _roleManagerMock.Object);
        }

        [Test]
        public void Login_ReturnsView()
        {
            var result = _controller.Login();
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Login_Post_InvalidModel_ReturnsView()
        {
            _controller.ModelState.AddModelError("Email", "Required");
            var result = await _controller.Login(new LoginViewModel());
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Logout_RedirectsToHome()
        {
            var result = await _controller.Logout();
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual("Home", redirectResult.ControllerName);
        }

        [Test]
        public void Register_ReturnsViewWithRoles()
        {
            var result = _controller.Register();
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            var model = viewResult.Model as RegisterViewModel;
            Assert.IsNotNull(model);
            Assert.IsNotEmpty(model.AvailableRoles);
        }

        [Test]
        public async Task Register_Post_InvalidModel_ReturnsViewWithRoles()
        {
            _controller.ModelState.AddModelError("Email", "Required");
            var result = await _controller.Register(new RegisterViewModel());
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOf<RegisterViewModel>(viewResult.Model);
        }
    }
}