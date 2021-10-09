using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AvailabilityTypeConfiguration : IEntityTypeConfiguration<AvailabilityType>
    {
        public void Configure(EntityTypeBuilder<AvailabilityType> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Type)
                .HasMaxLength(25)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}