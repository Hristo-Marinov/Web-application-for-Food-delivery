using FoodEx.Controllers;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
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
        public void SetUp()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

            var contextAccessor = new Mock<Microsoft.AspNetCore.Http.IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(_userManagerMock.Object,
                contextAccessor.Object, userPrincipalFactory.Object, null, null, null, null);

            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStore.Object, null, null, null, null);

            _controller = new AccountController(
                _userManagerMock.Object,
                _signInManagerMock.Object,
                _roleManagerMock.Object);
        }

        [Test]
        public void Login_Get_ReturnsView()
        {
            var result = _controller.Login() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Login_Post_InvalidModel_ReturnsViewWithModel()
        {
            _controller.ModelState.AddModelError("Email", "Required");

            var model = new LoginViewModel();
            var result = await _controller.Login(model) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(model));
        }

        [Test]
        public async Task Login_Post_ValidCredentials_RedirectsToHome()
        {
            var model = new LoginViewModel { Email = "test@example.com", Password = "Pass123!", RememberMe = false };
            var user = new ApplicationUser { Email = model.Email };

            _userManagerMock.Setup(u => u.FindByEmailAsync(model.Email)).ReturnsAsync(user);
            _signInManagerMock.Setup(s => s.PasswordSignInAsync(user, model.Password, model.RememberMe, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var result = await _controller.Login(model) as RedirectToActionResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Register_Get_ReturnsViewWithRoles()
        {
            var result = _controller.Register() as ViewResult;
            var model = result?.Model as RegisterViewModel;

            Assert.That(model, Is.Not.Null);
            Assert.That(model.AvailableRoles.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task Register_Post_InvalidModel_ReturnsViewWithModel()
        {
            _controller.ModelState.AddModelError("Email", "Required");

            var model = new RegisterViewModel();
            var result = await _controller.Register(model) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(model));
        }

        [Test]
        public async Task Logout_CallsSignOutAndRedirects()
        {
            var result = await _controller.Logout() as RedirectToActionResult;

            _signInManagerMock.Verify(s => s.SignOutAsync(), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }
    }
}
