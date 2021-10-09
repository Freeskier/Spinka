using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class MedicalServiceForEduBlockConfiguration : IEntityTypeConfiguration<MedicalServiceForEduBlock>
    {
        public void Configure(EntityTypeBuilder<MedicalServiceForEduBlock> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Vehicle)
                .WithOne(x => x.MedicalServiceForEduBlock)
                .HasForeignKey<MedicalServiceForEduBlock>(x => x.AmbulanceVehicleId);

            builder.Property(x => x.MedicalServiceType)
                .HasConversion<string>();
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}