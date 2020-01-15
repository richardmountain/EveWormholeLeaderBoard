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
    public class CorporationRepositoryTest
    {
        private CorporationRepository _repository;

        //[TestMethod]
        //public void AddValidTest()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<PodLabsContext>()
        //                   .UseInMemoryDatabase("Add_Valid_Test")
        //                   .Options;

        //    _repository = new CorporationRepository(new PodLabsContext(options));
        //    _repository.Add(new Corporation(1)
        //    {
        //        CeoId = 2071244718,
        //        CreatorId = 96180477,
        //        MemberCount = 28,
        //        Name = "Isolation Cult",
        //        Shares = 1000,
        //        TaxRate = 0.05,
        //        Ticker = "1.5.0"
        //    });

        //    // Act
        //    using (var context = new PodLabsContext(options))
        //    {
        //        var results = context.Corporations.FirstOrDefault();

        //        // Assert
        //        Assert.AreEqual("Isolation Cult", results.Name);
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
                _repository = new CorporationRepository(context);
                context.Add(new Corporation(1)
                {
                    CeoId = 2071244718,
                    CreatorId = 96180477,
                    MemberCount = 28,
                    Name = "Isolation Cult",
                    Shares = 1000,
                    TaxRate = 0.05,
                    Ticker = "1.5.0"
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
