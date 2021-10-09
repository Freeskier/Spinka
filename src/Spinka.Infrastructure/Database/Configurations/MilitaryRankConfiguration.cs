using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Database.Configurations
{
    public class MilitaryRankConfiguration : IEntityTypeConfiguration<MilitaryRank>
    {
       public void Configure(EntityTypeBuilder<MilitaryRank> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.FullRankPl)
                .HasMaxLength(25);
            builder.Property(x => x.FullRankEn)
                .HasMaxLength(35);
            builder.Property(x => x.Nato)
                .HasMaxLength(4);
            builder.Property(x => x.AcrRankPl)
                .HasMaxLength(20);
            builder.Property(x => x.AcrRankEn)
                .HasMaxLength(20);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}