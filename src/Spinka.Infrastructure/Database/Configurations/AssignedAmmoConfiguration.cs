using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedAmmoConfiguration : IEntityTypeConfiguration<AssignedAmmo>
    {
        public void Configure(EntityTypeBuilder<AssignedAmmo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AssignedAmmo)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.Ammo)
                .WithMany(x => x.AssignedAmmo)
                .HasForeignKey(x => x.AmmoId);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}