using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class FightingEntityTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var fightingEntity = new FightingEntity()
            {
                AllianceId = 0,
                CorporationId = 98614694,
                CharacterId = 2071244718,
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
            var result = fightingEntity.Validate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailTest()
        {
            // Arrange
            var fightingEntity = new FightingEntity();

            // Act
            var result = fightingEntity.Validate();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
