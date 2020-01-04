using Microsoft.EntityFrameworkCore;
using PodLabs.Core.Classes.Local;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracker>().HasData(
                new Tracker(1) { IsAlliance = false, TrackerId = 98614694 },            // Isolation Cult
                new Tracker(2) { IsAlliance = true, TrackerId = 99005065 },             // Hard Knocks Citizens
                new Tracker(3) { IsAlliance = true, TrackerId = 99003144 }              // Scary Wormhole People
            );
        }
    }
}
