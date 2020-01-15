using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.zKillboard;
using System;

namespace PodLabs.Core.EntityConfigurations.zKillboard
{
    public class PositionEntityConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
        }
    }
}
