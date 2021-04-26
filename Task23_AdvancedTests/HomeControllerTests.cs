using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task23_Advanced.Controllers;
using System.Web.Mvc;

namespace Task23_AdvancedTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeControllerReturnsView_ShouldReturnTrue()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
