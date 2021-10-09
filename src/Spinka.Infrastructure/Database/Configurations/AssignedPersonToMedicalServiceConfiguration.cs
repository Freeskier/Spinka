using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedPersonToMedicalServiceConfiguration : IEntityTypeConfiguration<AssignedPersonToMedicalService>
    {
        public void Configure(EntityTypeBuilder<AssignedPersonToMedicalService> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.MedicalStaff)
                .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.MedicalServiceForEduBlock)
                .WithMany(x => x.MedicalStaff)
                .HasForeignKey(x => x.MedicalServiceForEduBlockId);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}