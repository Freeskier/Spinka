using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class PersonAuthorisedForEduBlockFunctionConfiguration : IEntityTypeConfiguration<PersonAuthorisedForEduBlockFunction>
    {
        public void Configure(EntityTypeBuilder<PersonAuthorisedForEduBlockFunction> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.AuthorizationsType)
                .WithMany(x => x.PersonAuthorisedForEduBlockFunctions)
                .HasForeignKey(x => x.AuthorisationsTypeId);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonAuthorisedForEduBlockFunctions)
                .HasForeignKey(x => x.PersonId);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}