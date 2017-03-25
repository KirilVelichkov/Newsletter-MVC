using Moq;
using NewsLetter.Auth.Identity.Contracts;
using NewsLetter.ViewModels.Account;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace NewsLetter.MVC.Controllers.Tests.AccountControllerTests
{
    [TestFixture]
   public class Login_Should
    {
        [Test]
        public void Have_AllowAnonymous_Attribute_Get()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Login", new Type[0]);
            
            // Act
            var hasAttr = method.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Return_Correct_View()
        {
            // Arrange
            var mockedAuthService = new Mock<IAuthService>();
            var controller = new AccountController(mockedAuthService.Object);

            // Act Assert
            controller.WithCallTo(c => c.Login()).ShouldRenderDefaultView();
        }

        [Test]
        public void Have_AllowAnonymous_Attribute_Post()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Login", new Type[] { typeof(LoginViewModel), typeof(string) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_HttpPost_Attribute_Post()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Login", new Type[] { typeof(LoginViewModel), typeof(string) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_ValidateAntiForgeryToken_Attribute_Post()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Login", new Type[] { typeof(LoginViewModel), typeof(string) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
