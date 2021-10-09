using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AuthorizationsTypePermissionsConfiguration : IEntityTypeConfiguration<AuthorizationsTypePermissions>
    {
        public void Configure(EntityTypeBuilder<AuthorizationsTypePermissions> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AuthorizationsType)
                .WithMany(x => x.AuthorizationsTypePermissions)
                .HasForeignKey(x => x.AuthorizationsTypeId);

            builder.HasOne(x => x.Permission)
                .WithMany(x => x.AuthorizationsTypePermissions)
                .HasForeignKey(x => x.PermissionId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}