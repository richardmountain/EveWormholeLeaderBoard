using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.Swagger;

namespace PodLabs.UnitTest.Core.Classes.Swagger
{
    [TestClass]
    public class TrackerRepositoryTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var corporation = new Corporation()
            {
                CeoId = 2071244718,
                CreatorId = 96180477,
                MemberCount = 28,
                Name = "Isolation Cult",
                Shares = 1000,
                TaxRate = 0.05,
                Ticker = "1.5.0"
            };

            // Act
            var result = corporation.Validate();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
