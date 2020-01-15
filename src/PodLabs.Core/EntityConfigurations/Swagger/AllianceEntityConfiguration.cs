using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.Core.EntityConfigurations.Swagger
{
    public class AllianceEntityConfiguration : IEntityTypeConfiguration<Alliance>
    {
        public void Configure(EntityTypeBuilder<Alliance> builder)
        {
            builder.ToTable("Alliance");
            builder.HasMany(a => a.Corporations).WithOne(c => c.Alliance);
        }
    }
}
