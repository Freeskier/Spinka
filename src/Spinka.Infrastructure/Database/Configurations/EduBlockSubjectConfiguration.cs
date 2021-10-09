using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class EduBlockSubjectConfiguration : IEntityTypeConfiguration<EduBlockSubject>
    {
        public void Configure(EntityTypeBuilder<EduBlockSubject> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TrainingArea)
                .WithMany(x => x.EduBlockSubjects)
                .HasForeignKey(x => x.TrainingAreaId);
            
            builder.Property(x => x.Subject)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.IsCountedIn)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}