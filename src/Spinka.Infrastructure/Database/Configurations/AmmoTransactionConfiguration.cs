using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AmmoTransactionConfiguration : IEntityTypeConfiguration<AmmoTransaction>
    {
        public void Configure(EntityTypeBuilder<AmmoTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.CurrentAmmoLimitsForDepartment)
                .WithMany(x => x.AmmoTransactions)
                .HasForeignKey(x => x.CurrentAmmoLimitsForDepartmentId);

            builder.HasOne(x => x.AmmoTransactionType)
                .WithMany(x => x.AmmoTransactions)
                .HasForeignKey(x => x.AmmoTransactionTypeId);

            builder.Property(x => x.Remarks)
                .HasMaxLength(250);
            builder.Property(x => x.TransactionDateTime)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}