using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AdditionalPersonnelConfiguration : IEntityTypeConfiguration<AdditionalPersonnel>
    {
        public void Configure(EntityTypeBuilder<AdditionalPersonnel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AdditionalPersonnel)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.AdditionalPersonnel)
                .HasForeignKey(x => x.PersonId);
            
            builder.Property(x => x.IsLivePlayer)
                .HasDefaultValue(false);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}