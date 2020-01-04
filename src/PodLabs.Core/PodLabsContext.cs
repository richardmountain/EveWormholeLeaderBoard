using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Classes.zKillboard;

namespace PodLabs.Core
{
    public class PodLabsContext : DbContext
    {
        public PodLabsContext() { }
        public PodLabsContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Killmail> Killmails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=app;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracker>().HasData(
                new Tracker(1) { IsAlliance = false, TrackerId = 98614694 },            // Isolation Cult
                new Tracker(2) { IsAlliance = true, TrackerId = 99005065 },             // Hard Knocks Citizens
                new Tracker(3) { IsAlliance = true, TrackerId = 99003144 },             // Scary Wormhole People
                new Tracker(4) { IsAlliance = true, TrackerId = 99009583 },             // Snuggly Wormhole People
                new Tracker(5) { IsAlliance = true, TrackerId = 99006113 }              // No Vacancies.
                );
        }

    }
}
