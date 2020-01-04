using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.Local;

namespace PodLabs.UnitTest.Core.Classes.Local
{
    [TestClass]
    public class TrackerTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var alliance = new Tracker()
            {
                IsAlliance = false,
                TrackerId = 1
            };

            // Act
            var result = alliance.Validate();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
