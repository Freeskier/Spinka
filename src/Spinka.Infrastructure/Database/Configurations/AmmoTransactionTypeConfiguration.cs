using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AmmoTransactionTypeConfiguration : IEntityTypeConfiguration<AmmoTransactionType>
    {
        public void Configure(EntityTypeBuilder<AmmoTransactionType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.Acronym)
                .HasMaxLength(5)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}