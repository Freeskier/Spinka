using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedTrainingFacilityConfiguration : IEntityTypeConfiguration<AssignedTrainingFacility>
    {
        public void Configure(EntityTypeBuilder<AssignedTrainingFacility> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AssignedTrainingFacilities)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.TrainingFacility)
                .WithMany(x => x.AssignedTrainingFacilities)
                .HasForeignKey(x => x.TrainingFacilityId);

            builder.Property(x => x.ApprovedTime)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            builder.Property(x => x.EndOn)
                .IsRequired();
            builder.Property(x => x.Notes)
                .HasMaxLength(250);
            builder.Property(x => x.StartTime)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }   
    }
}