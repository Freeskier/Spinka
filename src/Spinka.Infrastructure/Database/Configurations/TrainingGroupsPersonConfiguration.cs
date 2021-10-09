using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class TrainingGroupsPersonConfiguration : IEntityTypeConfiguration<TrainingGroupsPerson>
    {
        public void Configure(EntityTypeBuilder<TrainingGroupsPerson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonInTrainingGroups)
                .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.TrainingGroup)
                .WithMany(x => x.TrainingGroupsPersons)
                .HasForeignKey(x => x.TrainingGroupId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}