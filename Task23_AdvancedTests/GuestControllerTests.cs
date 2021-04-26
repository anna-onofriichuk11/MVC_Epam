using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task23_Advanced.Controllers;
using System.Web.Mvc;

namespace Task23_AdvancedTests
{
    [TestClass]
    public class GuestControllerTests
    {
        [TestMethod]
        public void GuestControllerReturnsView_ShouldReturnTrue()
        {
            // Arrange
            GuestController controller = new GuestController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
