using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.Swagger;
using PodLabs.Core.Classes.zKillboard;
using System;

namespace PodLabs.Core.EntityConfigurations.zKillboard
{
    public class VictimEntityConfiguration : IEntityTypeConfiguration<Victim>
    {
        public void Configure(EntityTypeBuilder<Victim> builder)
        {
            builder.ToTable("Victim");
            builder.HasOne(c => c.Corporation).WithOne().HasPrincipalKey<Corporation>(c => c.CorporationId);
        }
    }
}
