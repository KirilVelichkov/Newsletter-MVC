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
    public class Register_Should
    {
        [Test]

        public void Have_AllowAnonymous_Attribute_Get()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Register", new Type[0]);

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
            controller.WithCallTo(c => c.Register()).ShouldRenderDefaultView();
        }


        [Test]
        public void Have_AllowAnonymous_Attribute_Post()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Register", new Type[] { typeof(RegisterViewModel) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_HttpPost_Attribute_Post()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Register", new Type[] { typeof(RegisterViewModel) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_ValidateAntiForgeryToken_Attribute_Post()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("Register", new Type[] { typeof(RegisterViewModel)});

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
