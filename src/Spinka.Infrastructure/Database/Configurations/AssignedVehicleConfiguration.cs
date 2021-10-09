using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedVehicleConfiguration : IEntityTypeConfiguration<AssignedVehicle>
    {
        public void Configure(EntityTypeBuilder<AssignedVehicle> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AssignedVehicles)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.AssignedVehicles)
                .HasForeignKey(x => x.VehicleId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}