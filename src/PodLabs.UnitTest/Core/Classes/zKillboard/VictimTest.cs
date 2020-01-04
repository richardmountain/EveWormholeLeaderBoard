using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class VictimTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var victim = new Victim()
            {
                AllianceId = 0,
                CorporationId = 98614694,
                ShipTypeId = 1,
                DamageTaken = 1000,
                //Corporation = new PodLabs.Core.Classes.Swagger.Corporation()
                //{
                //    CeoId = 2071244718,
                //    CreatorId = 96180477,
                //    MemberCount = 28,
                //    Name = "Isolation Cult",
                //    Shares = 1000,
                //    TaxRate = 0.05,
                //    Ticker = "1.5.0"
                //}
            };

            // Act
            var result = victim.Validate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailTest()
        {
            // Arrange
            var victim = new Victim();

            // Act
            var result = victim.Validate();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
