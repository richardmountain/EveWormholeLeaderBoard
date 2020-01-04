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
    public class TrackerRepositoryTest
    {

        private TrackerRepository _repository;

        [TestMethod]
        public void AddValidTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PodLabsContext>()
                           .UseInMemoryDatabase("Add_Valid_Test")
                           .Options;

            _repository = new TrackerRepository(new PodLabsContext(options));
            _repository.Add(new Tracker(1)
            {
                IsAlliance = false,
                TrackerId = 98614694
            });

            // Act
            using (var context = new PodLabsContext(options))
            {
                var results = context.Trackers.FirstOrDefault();

                // Assert
                Assert.AreEqual(98614694, results.TrackerId);
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
                _repository = new TrackerRepository(context);
                context.Add(new Tracker(1) { IsAlliance = false, TrackerId = 98614694 });            // Isolation Cult
                context.Add(new Tracker(2) { IsAlliance = true, TrackerId = 99005065 });             // Hard Knocks Citizens
                context.Add(new Tracker(3) { IsAlliance = true, TrackerId = 99003144 });             // Scary Wormhole People
                context.Add(new Tracker(4) { IsAlliance = true, TrackerId = 99009583 });             // Snuggly Wormhole People);
                context.SaveChanges();
             
                // Act
                var results = _repository.GetAllAsync().Result.Count;
                
                // Assert
                Assert.AreEqual(4, results);
            }
        }
    }
}
