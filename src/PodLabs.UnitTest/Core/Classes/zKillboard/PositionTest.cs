using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var position = new Position();

            // Act
            var result = position.Validate();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
