using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class DayRepAcronymConfiguration : IEntityTypeConfiguration<DayRepAcronym>
    {
        public void Configure(EntityTypeBuilder<DayRepAcronym> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(4)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Color)
                .HasMaxLength(8)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}