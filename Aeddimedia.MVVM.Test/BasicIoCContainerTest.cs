using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aeddimedia.MVVM.Test
{
    /// <summary>
    /// Testclass for the <see cref="BasicIoCContainer"/> class.
    /// </summary>
    [TestClass]
    public class BasicIoCContainerTest
    {
        [TestMethod]
        public void WhenGettingInstanceOfType_TheCorrectInstanceShouldBeReturned()
        {
            // Arrange
            var testObject = new BasicIoCContainer();
            testObject.RegisterInstace<string, string>();

            // Act
            var actualResult = testObject.GetInstance<string>();

            // Assert
            Assert.AreEqual(typeof(string), actualResult.GetType());
        }
    }
}
