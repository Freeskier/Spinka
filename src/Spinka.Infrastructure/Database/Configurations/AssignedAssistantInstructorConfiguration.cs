using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class AssignedAssistantInstructorConfiguration : IEntityTypeConfiguration<AssignedAssistantInstructor>
    {
        public void Configure(EntityTypeBuilder<AssignedAssistantInstructor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EduBlock)
                .WithMany(x => x.AssistantInstructors)
                .HasForeignKey(x => x.EduBlockId);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.AssistantInstructors)
                .HasForeignKey(x => x.PersonId);
            
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}