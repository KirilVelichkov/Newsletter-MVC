using NewsLetter.Auth.Identity.Contracts;
using NewsLetter.MVC.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.MVC.Controllers.Tests.AccountControllerTests
{
    [TestFixture]
    public class Constructor_Should
    { 
        [Test]
        public void Throw_When_authService_IsNull()
        {
            // Arrange Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AccountController(null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("authService"));
        }
    }
}
