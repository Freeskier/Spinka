using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class EduBlockHistoryConfiguration : IEntityTypeConfiguration<EduBlockHistory>
    {

        public void Configure(EntityTypeBuilder<EduBlockHistory> builder)
        {
            builder.HasKey(x => x.Id);
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
        }
    }
}