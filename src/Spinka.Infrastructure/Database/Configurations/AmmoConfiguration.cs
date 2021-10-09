using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AmmoConfiguration : IEntityTypeConfiguration<Ammo>
    {
        public void Configure(EntityTypeBuilder<Ammo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AmmoType)
                .WithMany(x => x.Ammo)
                .HasForeignKey(x => x.AmmoTypeId);

            builder.HasOne(x => x.MeasureUnit)
                .WithMany(x => x.Ammo)
                .HasForeignKey(x => x.MeasureUnitId);
            
            builder.Property(x => x.LogIndex)
                .HasMaxLength(13)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.IsDangerous)
                .HasDefaultValue(false);
        }
    }
}