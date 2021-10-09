using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AvailabilityRoleConfiguration : IEntityTypeConfiguration<AvailabilityRole>
    {
        public void Configure(EntityTypeBuilder<AvailabilityRole> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Role)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}