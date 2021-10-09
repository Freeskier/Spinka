using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class FunctionForEduBlockConfiguration : IEntityTypeConfiguration<FunctionForEduBlock>
    {
        public void Configure(EntityTypeBuilder<FunctionForEduBlock> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}