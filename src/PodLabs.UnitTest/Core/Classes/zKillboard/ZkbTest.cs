using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.UnitTest.Core.Classes.zKillboard
{
    [TestClass]
    public class ZKbTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            // Arrange
            var zkb = new Zkb()
            {
                Hash = "97b3aad21c769055085e1355bcbec37403d45c88",
                FittedValue = 41546.81,
                TotalValue = 41546.81,
                Points = 1,
                NPC = false,
                Esi = "https://esi.evetech.net/latest/killmails/80796872/97b3aad21c769055085e1355bcbec37403d45c88/",
                Url = "https://zkillboard.com/kill/80796872/"
            };

            // Act
            var result = zkb.Validate();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateFailTest()
        {
            // Arrange
            var zkb = new Zkb();

            // Act
            var result = zkb.Validate();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
