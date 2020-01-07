using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Classes.zKillboard;
using System;

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
            try
            {
                if (!optionsBuilder.IsConfigured)
                    optionsBuilder.UseMySql(Settings.ReadSettings().ConnectionString);
            } catch(Exception)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracker>().HasData(
                new Tracker(1) { IsAlliance = false, TrackerId = 98614694 },            // Isolation Cult
                new Tracker(2) { IsAlliance = true, TrackerId = 99007237 },             // L A Z E R H A W K S
                new Tracker(3) { IsAlliance = true, TrackerId = 99003144 },             // Scary Wormhole People
                new Tracker(4) { IsAlliance = true, TrackerId = 99009583 },             // Snuggly Wormhole People
                new Tracker(5) { IsAlliance = true, TrackerId = 99006113 },             // No Vacancies.
                new Tracker(6) { IsAlliance = true, TrackerId = 99006319 },             // Wingspan Delivery Network
                new Tracker(7) { IsAlliance = true, TrackerId = 99007192 },             // Sanctus Silentium
                new Tracker(8) { IsAlliance = true, TrackerId = 99006117 }              // Ember Sands
                );
        }

    }
}
