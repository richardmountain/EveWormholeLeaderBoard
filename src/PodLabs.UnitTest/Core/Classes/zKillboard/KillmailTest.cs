using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class KillmailTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var killmail = new Killmail()
            {
                Attackers = new List<Attacker>()
                {
                    new Attacker()
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
                    }
                },
                KillmailId = 80606339,
                SolarSystemId = 31000219,
                Victim = new Victim()
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
                },
                Zkb = new Zkb()
                {
                    Hash = "97b3aad21c769055085e1355bcbec37403d45c88",
                    FittedValue = 41546.81,
                    TotalValue = 41546.81,
                    Points = 1,
                    NPC = false,
                    Esi = "https://esi.evetech.net/latest/killmails/80796872/97b3aad21c769055085e1355bcbec37403d45c88/",
                    Url = "https://zkillboard.com/kill/80796872/"
                }
            };

            // Act
            var result = killmail.Validate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailTest()
        {
            // Arrange
            var killmail = new Killmail();

            // Act
            var result = killmail.Validate();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
