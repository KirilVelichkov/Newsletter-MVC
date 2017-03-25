using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsLetter.MVC.Controllers.Tests.AccountControllerTests
{
    [TestFixture]
    public class LogOff_Should
    {
        [Test]
        public void Have_HttpPost_Attribute()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("LogOff", new Type[0]);

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_ValidateAntiForgeryToken_Attribute()
        {
            // Arrange
            var method = typeof(AccountController).GetMethod("LogOff", new Type[0]);

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
