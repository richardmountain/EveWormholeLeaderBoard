using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.Swagger;

namespace PodLabs.UnitTest.Core.Classes.Swagger
{
    [TestClass]
    public class TrackerTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var alliance = new Alliance()
            {
                CreatorCorporationId = 98367322,
                CreatorId = 1567970852,
                ExecutorCorporationId = 98040755,
                Name = "Hard Knocks Citizens",
                Ticker = "HKRAB"
            };

            // Act
            var result = alliance.Validate();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
