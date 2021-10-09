using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedAvailabilityTypeConfiguration : IEntityTypeConfiguration<AssignedAvailabilityType>
    {
        public void Configure(EntityTypeBuilder<AssignedAvailabilityType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.DayRep)
                .WithMany(x => x.AssignedAvailabilityTypes)
                .HasForeignKey(x => x.DayRepId);

            builder.HasOne(x => x.AvailabilityType)
                .WithMany(x => x.AssignedAvailabilityTypes)
                .HasForeignKey(x => x.AvailabilityTypeId);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}