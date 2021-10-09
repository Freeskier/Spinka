using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class GroupForDayRepConfiguration : IEntityTypeConfiguration<GroupForDayRep>
    {
        public void Configure(EntityTypeBuilder<GroupForDayRep> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.UnitDepartment)
                .WithMany(x => x.GroupForDayReps)
                .HasForeignKey(x => x.UnitDepartmentsId);
            
            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}