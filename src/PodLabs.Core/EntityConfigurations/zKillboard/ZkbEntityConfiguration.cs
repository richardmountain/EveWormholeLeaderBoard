using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.zKillboard;
using System;

namespace PodLabs.Core.EntityConfigurations.zKillboard
{
    public class ZkbEntityConfiguration : IEntityTypeConfiguration<Zkb>
    {
        public void Configure(EntityTypeBuilder<Zkb> builder)
        {
            builder.ToTable("Zkb");
            builder.Property(x => x.NPC).HasColumnType("bit");
            builder.Property(x => x.Solo).HasColumnType("bit");
            builder.Property(x => x.Awox).HasColumnType("bit");
        }
    }
}
