using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task23_Advanced.Controllers;
using System.Web.Mvc;

namespace Task23_AdvancedTests
{
    [TestClass]
    public class FormControllerTests
    {
        [TestMethod]
        public void FormControllerReturnsView_ShouldReturnTrue()
        {
            // Arrange
            FormController controller = new FormController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
