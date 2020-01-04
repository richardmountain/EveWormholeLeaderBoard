using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodLabs.Core;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Classes.zKillboard;
using PodLabs.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodLabs.UnitTest.Core.Repository
{
    [TestClass]
    public class KillmailRepositoryTest
    {
        private KillmailRepository _repository;

        [TestMethod]
        public void AddValidTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PodLabsContext>()
                           .UseInMemoryDatabase("Add_Valid_Test")
                           .Options;

            _repository = new KillmailRepository(new PodLabsContext(options));
            _repository.Add(new Killmail(1)
            {
                KillmailId = 80014433,
                SolarSystemId = 30003852,
            });

            // Act
            using (var context = new PodLabsContext(options))
            {
                var results = context.Killmails.FirstOrDefault();

                // Assert
                Assert.AreEqual(80014433, results.KillmailId);
            }


        }

        [TestMethod]
        public void GetAllValidTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PodLabsContext>()
                           .UseInMemoryDatabase("GetAll_Valid_Test")
                           .Options;

            using (var context = new PodLabsContext(options))
            {
                _repository = new KillmailRepository(context);
                context.Add(new Killmail(1)
                {
                    KillmailId = 80014433,
                    SolarSystemId = 30003852,
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
