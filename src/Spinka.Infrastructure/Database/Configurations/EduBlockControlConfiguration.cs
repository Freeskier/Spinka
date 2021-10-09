using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class EduBlockConxrolConfiguration : IEntityTypeConfiguration<EduBlockControl>
    {
        public void Configure(EntityTypeBuilder<EduBlockControl> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.EduBlockControls)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.EduBlockControls)
                .HasForeignKey(x => x.EduBlockId);
            
            builder.Property(x => x.LastTimeModified)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            builder.Property(x => x.AdminLogin)
                .IsRequired()
                .HasMaxLength(100);
            /*builder.Property(x => x.Attended)
                .HasDefaultValue(true)
                .IsRequired();*/
            builder.Property(x => x.AbsenceReason)
                .HasMaxLength(250);
            builder.Property(x => x.Remarks)
                .HasMaxLength(100);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}