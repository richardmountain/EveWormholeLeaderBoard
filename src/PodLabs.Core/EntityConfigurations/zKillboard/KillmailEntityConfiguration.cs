using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.zKillboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.Core.EntityConfigurations.zKillboard
{
    public class KillmailEntityConfiguration : IEntityTypeConfiguration<Killmail>
    {
        public void Configure(EntityTypeBuilder<Killmail> builder)
        {
            builder.ToTable("Killmail");
            //builder.HasOne(k => k.Victim).WithMany().HasPrincipalKey(v => v.CharacterId);

        }
    }
}
