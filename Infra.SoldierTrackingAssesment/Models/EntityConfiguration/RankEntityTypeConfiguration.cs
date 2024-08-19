using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class RankEntityTypeConfiguration : BaseEntityTypeConfiguration<Rank>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Rank> builder)
        {
            builder
            .Property(a => a.Title)
            .HasMaxLength(255);

            builder.HasMany(e => e.Soldiers)
                   .WithOne(e => e.Rank)
                   .HasForeignKey(e => e.RankId)
                   .IsRequired();
        }
    }
}
