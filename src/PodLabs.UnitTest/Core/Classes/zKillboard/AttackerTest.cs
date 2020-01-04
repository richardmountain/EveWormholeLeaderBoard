using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class AttackerTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var attacker = new Attacker()
            {
                AllianceId = 0,
                CorporationId = 98614694,
                DamageDone = 1,
                WeaponTypeId = 1,
                ShipTypeId = 1,
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
            var result = attacker.Validate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailTest()
        {
            // Arrange
            var attacker = new Attacker();

            // Act
            var result = attacker.Validate();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
