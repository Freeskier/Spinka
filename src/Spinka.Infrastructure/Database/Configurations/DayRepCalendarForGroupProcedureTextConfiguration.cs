using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models.ProcedureModels;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class DayRepCalendarForGroupProcedureTextConfiguration: IEntityTypeConfiguration<DayRepCalendarForGroupProcedureText>
    {
        public void Configure(EntityTypeBuilder<DayRepCalendarForGroupProcedureText> builder)
        {
            builder.HasNoKey();
        }
    }
}
