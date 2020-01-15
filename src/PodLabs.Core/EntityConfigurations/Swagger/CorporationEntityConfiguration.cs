using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.Swagger;
using System;

namespace PodLabs.Core.EntityConfigurations.Swagger
{
    public class CorporationEntityConfiguration : IEntityTypeConfiguration<Corporation>
    {
        public void Configure(EntityTypeBuilder<Corporation> builder)
        {
            builder.ToTable("Corporation");
            builder.Property(x => x.WarEligible).HasColumnType("bit");
            builder.HasOne(c => c.Alliance).WithMany(a => a.Corporations).HasPrincipalKey(a => a.AllianceId);
        }
    }
}
