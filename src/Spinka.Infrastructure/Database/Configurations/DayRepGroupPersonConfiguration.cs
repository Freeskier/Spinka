using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class DayRepGroupPersonConfiguration : IEntityTypeConfiguration<DayRepGroupPerson>
    {
        public void Configure(EntityTypeBuilder<DayRepGroupPerson> builder)
        {
            builder.HasKey(x => x.Id);
           
            builder.HasOne(x => x.Person)
                .WithMany(x => x.DayRepGroupPersons)
                .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.GroupForDayRep)
                .WithMany(x => x.DayRepGroupPersons)
                .HasForeignKey(x => x.GroupForDayRepId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false); 

            builder.Property(x => x.IsDelegated)
                .HasDefaultValue(false);

        }
    }
}