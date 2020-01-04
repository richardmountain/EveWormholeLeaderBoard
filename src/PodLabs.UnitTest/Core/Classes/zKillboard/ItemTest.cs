using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var item = new Item()
            {
                ItemTypeId = 1,
                QuantityDropped = 1,
                QuantityDestroyed = 1
            };

            // Act
            var result = item.Validate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailTest()
        {
            // Arrange
            var item = new Item();

            // Act
            var result = item.Validate();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
