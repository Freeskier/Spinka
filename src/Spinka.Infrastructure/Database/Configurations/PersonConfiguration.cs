using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.MilitaryRank)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.MilitaryRankId);

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Father)
                .HasMaxLength(60)
                .IsRequired();
            builder.Property(x => x.Pesel)
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(x => x.Login)
                .HasMaxLength(20);
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}