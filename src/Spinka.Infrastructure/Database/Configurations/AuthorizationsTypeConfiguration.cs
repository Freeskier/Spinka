using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AuthorizationsTypeConfiguration : IEntityTypeConfiguration<AuthorizationsType>
    {
        public void Configure(EntityTypeBuilder<AuthorizationsType> builder)
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