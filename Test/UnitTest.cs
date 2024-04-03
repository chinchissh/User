using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Users.Controllers;

namespace Users.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void TestValidRegistration()
        {
            var controller = new AccountController();
            var login = "validlogin";
            var password = "ValidPassword1!";
            var email = "test@example.com";

            var result = controller.Register(login, password, email) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public void TestInvalidLogin_TooShort()
        {
            var controller = new AccountController();
            var login = "aaa";
            var password = "ValidPassword1!";
            var email = "test@example.com";

            var result = controller.Register(login, password, email) as ViewResult;

            Assert.IsNotNull(result); 
            Assert.IsFalse(result.ViewData.ModelState.IsValid); 
            Assert.IsTrue(result.ViewData.ModelState.ContainsKey("login")); 
        }
    }
}
