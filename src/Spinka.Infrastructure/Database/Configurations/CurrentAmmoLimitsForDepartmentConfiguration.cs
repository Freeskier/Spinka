using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class CurrentAmmoLimitsForDepartmentConfiguration : IEntityTypeConfiguration<CurrentAmmoLimitsForDepartment>
    {
        public void Configure(EntityTypeBuilder<CurrentAmmoLimitsForDepartment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UnitDepartment)
                .WithMany(x => x.CurrentAmmoLimitsForDepartments)
                .HasForeignKey(x => x.UnitDepartmentsId);

            builder.HasOne(x => x.Ammo)
                .WithMany(x => x.CurrentAmmoLimitsForDepartments)
                .HasForeignKey(x => x.AmmoId);

            builder.Property(x => x.ActualizationDate)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}