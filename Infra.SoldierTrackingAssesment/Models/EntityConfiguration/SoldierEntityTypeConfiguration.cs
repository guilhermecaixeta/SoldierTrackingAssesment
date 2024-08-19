using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class SoldierEntityTypeConfiguration : BaseEntityTypeConfiguration<Soldier>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Soldier> builder)
        {
            builder
                .Property(a => a.Name)
                .HasMaxLength(255);

            builder
                .HasOne(e => e.Country)
                .WithMany(e => e.Soldiers)
                .HasForeignKey(e => e.CountryId)
                .IsRequired();

            builder
                .HasMany(e => e.Trainings)
                .WithMany(e => e.Soldiers);
        }
    }
}
