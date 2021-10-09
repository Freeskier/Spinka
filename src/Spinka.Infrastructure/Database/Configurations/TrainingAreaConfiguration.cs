using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class TrainingAreaConfiguration : IEntityTypeConfiguration<TrainingArea>
    {
        public void Configure(EntityTypeBuilder<TrainingArea> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50);
            builder.Property(x => x.TrainingAcronym)
                .HasMaxLength(7);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}