using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class TrainingGroupsInDepartmentConfiguration : IEntityTypeConfiguration<TrainingGroupsInDepartment>
    {
        public void Configure(EntityTypeBuilder<TrainingGroupsInDepartment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TrainingGroup)
                .WithMany(x => x.TrainingGroupsInDepartments)
                .HasForeignKey(x => x.TrainingGroupId);

            builder.HasOne(x => x.UnitDepartment)
                .WithMany(x => x.TrainingGroupsInDepartments)
                .HasForeignKey(x => x.UnitDepartmentsId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}