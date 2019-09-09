using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aeddimedia.MVVM.Test
{
    /// <summary>
    /// Testclass for the <see cref="BasicIoCContainer"/> class.
    /// </summary>
    [TestClass]
    public class BasicIoCContainerTest
    {
        [TestMethod]
        public void WhenResolvingInstanceOfType_TheCorrectInstanceShouldBeReturned()
        {
            // Arrange
            var testObject = new BasicIoCContainer();
            testObject.RegisterInstance<IDummyInterface, DummyClass>();

            // Act
            var actualResult = testObject.Resolve<IDummyInterface>();

            // Assert
            Assert.AreEqual(typeof(DummyClass), actualResult.GetType());
        }

        [TestMethod]
        public void WhenResolvingInstanceOfTypeWithDependency_TheCorrectInstanceShouldBeReturned()
        {
            // Arrange
            var testObject = new BasicIoCContainer();
            testObject.RegisterInstance<IDummyInterface, DummyClass>();
            testObject.RegisterInstance<DependantDummyClass, DependantDummyClass>();

            // Act
            var actualResult = testObject.Resolve<DependantDummyClass>();

            // Assert
            Assert.AreEqual(typeof(DependantDummyClass), actualResult.GetType());
        }

        internal interface IDummyInterface
        {

        }

        internal class DummyClass : IDummyInterface
        {
            public DummyClass()
            {

            }
        }

        internal class DependantDummyClass
        {
            public DependantDummyClass(IDummyInterface dummyInterface)
            {

            }
        }
    }

}
