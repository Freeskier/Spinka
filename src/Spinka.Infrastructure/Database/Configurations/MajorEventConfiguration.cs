using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class MajorEventConfiguration : IEntityTypeConfiguration<MajorEvent>
    {
        public void Configure(EntityTypeBuilder<MajorEvent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EventType)
                .WithMany(x => x.MajorEvents)
                .HasForeignKey(x => x.EventTypeId);
            
            builder.HasOne(x => x.UnitDepartment)
                .WithMany(x => x.MajorEvents)
                .HasForeignKey(x => x.UnitDepartmentId);
            
            builder.Property(x => x.Name)
                .HasMaxLength(250);
            builder.Property(x => x.EndOn)
                .IsRequired();
            builder.Property(x => x.StartOn)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

        }
    }
}