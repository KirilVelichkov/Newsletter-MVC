using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.MVC.Controllers.Tests.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_articleService_IsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => {
                new HomeController(null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("articleService"));
        }
    }
}
