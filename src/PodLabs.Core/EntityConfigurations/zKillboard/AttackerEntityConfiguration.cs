using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.Core.EntityConfigurations.zKillboard
{
    public class AttackerEntityConfiguration : IEntityTypeConfiguration<Attacker>
    {
        public void Configure(EntityTypeBuilder<Attacker> builder)
        {
            builder.ToTable("Attacker");
            builder.Property(x => x.FinalBlow).HasColumnType("bit");
        }
    }
}
