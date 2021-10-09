using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models.ProcedureModels;
using System;
using System.Collections.Generic;
using System.Text;
namespace Spinka.Infrastructure.Database.Configurations
{
    public class DayRepNumbersForGroupInnerDashBoardProcedureConfiguration: IEntityTypeConfiguration<DayRepNumbersForGroupInnerDashBoardProcedure>
    {
        public void  Configure(EntityTypeBuilder<DayRepNumbersForGroupInnerDashBoardProcedure> builder)
        {
            builder.HasNoKey();
        }
    }
}
