using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.RegisterNumber)
                .HasMaxLength(7)
                .IsRequired();
            builder.Property(x => x.VehicleType)
                .HasConversion<string>();
            builder.Property(x => x.Brand)
                .HasMaxLength(35)
                .IsRequired();
            builder.Property(x => x.Model)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}