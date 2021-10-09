using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class DayRepConfiguration : IEntityTypeConfiguration<DayRep>
    {
        public void Configure(EntityTypeBuilder<DayRep> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.DayRepAcronym)
                .WithMany(x => x.DayReps)
                .HasForeignKey(x => x.DayRepAcronymId);

            builder.HasOne(x => x.DayRepGroupPerson)
                .WithMany(x => x.DayReps)
                .HasForeignKey(x => x.DayRepGroupPersonId);

            builder.Property(x => x.Day)
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Description)
                .HasMaxLength(50);
            builder.Property(x => x.Location)
                .HasMaxLength(50);
            builder.Property(x => x.Login)
                .HasMaxLength(20);
            builder.Property(x => x.LastUpdate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}