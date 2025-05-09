using MvcMovie.Controllers;

namespace MvcMovie.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HelloWorldController_CanCountVisits()
        {
            // arrange
            var controller = new HelloWorldController();

            // act
            var result = controller.Welcome("test", 1);

            // assert
            Assert.AreEqual("Hello test, ID: 1, you have visited: 0 times", result);
        }
    }
}