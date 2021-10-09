using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AuxPersonForEduBlockConfiguration : IEntityTypeConfiguration<AuxPersonForEduBlock>
    {
        public void Configure(EntityTypeBuilder<AuxPersonForEduBlock> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Person)
                .WithMany(x => x.AuxPersons)
                .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AuxPersons)
                .HasForeignKey(x => x.EduBlockId);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}