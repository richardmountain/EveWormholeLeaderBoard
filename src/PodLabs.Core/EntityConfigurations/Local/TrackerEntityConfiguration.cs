using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodLabs.Core.Classes.Local;

namespace PodLabs.Core.EntityConfigurations.Local
{
    public class TrackerEntityConfiguration : IEntityTypeConfiguration<Tracker>
    {
        public void Configure(EntityTypeBuilder<Tracker> builder)
        {
            builder.ToTable("Tracker");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsAlliance).HasColumnType("bit");
        }
    }
}
