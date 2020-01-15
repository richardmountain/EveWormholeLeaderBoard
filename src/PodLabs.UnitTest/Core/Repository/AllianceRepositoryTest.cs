using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodLabs.UnitTest.Core.Repository
{
    [TestClass]
    public class AllianceRepositoryTest
    {
        private AllianceRepository _repository;

        //[TestMethod]
        //public void AddValidTest()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<PodLabsContext>()
        //                   .UseInMemoryDatabase("Add_Valid_Test")
        //                   .Options;

        //    _repository = new AllianceRepository(new PodLabsContext(options));
        //    _repository.Add(new Alliance(1)
        //    {
        //        AllianceId = 99003144,
        //        CreatorCorporationId = 1705300610,
        //        CreatorId = 927945665,
        //        ExecutorCorporationId = 1705300610,
        //        Name = "Scary Wormhole People",
        //        Ticker = "WHBOO"
        //    });

        //    // Act
        //    using (var context = new PodLabsContext(options))
        //    {
        //        var results = context.Alliances.FirstOrDefault();

        //        // Assert
        //        Assert.AreEqual("Scary Wormhole People", results.Name);
        //    }


        //}

        [TestMethod]
        public void GetAllValidTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PodLabsContext>()
                           .UseInMemoryDatabase("GetAll_Valid_Test")
                           .Options;

            using (var context = new PodLabsContext(options))
            {
                _repository = new AllianceRepository(context);
                context.Add(new Alliance(1)
                {
                    AllianceId = 99003144,
                    CreatorCorporationId = 1705300610,
                    CreatorId = 927945665,
                    ExecutorCorporationId = 1705300610,
                    Name = "Scary Wormhole People",
                    Ticker = "WHBOO"
                });
                context.SaveChanges();

                // Act
                var results = _repository.GetAllAsync().Result.Count;

                // Assert
                Assert.AreEqual(1, results);
            }
        }
    }
}
