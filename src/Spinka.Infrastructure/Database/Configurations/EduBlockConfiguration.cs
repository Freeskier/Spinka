using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class EduBlockConfiguration : IEntityTypeConfiguration<EduBlock>
    {
        public void Configure(EntityTypeBuilder<EduBlock> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.EduBlockSubject)
                .WithMany(x => x.EduBlocks)
                .HasForeignKey(x => x.EduBlockSubjectId);
            
            builder.HasOne(x => x.MajorEvent)
                .WithMany(x => x.EduBlocks)
                .HasForeignKey(x => x.MajorEventId);
            
            builder.HasOne(x => x.MedicalServiceForEduBlock)
                .WithOne(x => x.EduBlock)
                .HasForeignKey<EduBlock>(x => x.MedicalServiceForEduBlockId);

            builder.Property(x => x.AdditionalInformation)
                .HasMaxLength(500);
            builder.Property(x => x.ApprovedTime)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            builder.Property(x => x.IsMedicalServiceRequired)
                .HasDefaultValue(false);
            builder.Property(x => x.Approved)
                .HasDefaultValue(false);
            builder.Property(x => x.EndOn)
                .IsRequired();
            builder.Property(x => x.StartTime)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.IsCancelled)
                .HasDefaultValue(false);
        }
    }
}