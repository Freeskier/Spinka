using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class PersonAuthorizationConfiguration : IEntityTypeConfiguration<PersonAuthorization>
    {
        public void Configure(EntityTypeBuilder<PersonAuthorization> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AuthorizationsType)
                .WithMany(x => x.PersonAuthorizations)
                .HasForeignKey(x => x.AuthorizationTypeId);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonAuthorizations)
                .HasForeignKey(x => x.PersonId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}