using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedTrainingGroupConfiguration : IEntityTypeConfiguration<AssignedTrainingGroup>
    {
        public void Configure(EntityTypeBuilder<AssignedTrainingGroup> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AssignedTrainingGroups)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.TrainingGroup)
                .WithMany(x => x.AssignedTrainingGroups)
                .HasForeignKey(x => x.TrainingGroupId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}