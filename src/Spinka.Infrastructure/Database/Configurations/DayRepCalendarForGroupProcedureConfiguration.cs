using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models.ProcedureModels;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class DayRepCalendarForGroupProcedureConfiguration : IEntityTypeConfiguration<DayRepCalendarForGroupProcedure>
    {
        public void Configure(EntityTypeBuilder<DayRepCalendarForGroupProcedure> builder)
        {
            builder.HasNoKey();
        }
    }
}
