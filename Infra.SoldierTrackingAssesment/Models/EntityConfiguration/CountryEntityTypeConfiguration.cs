using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class CountryEntityTypeConfiguration : BaseEntityTypeConfiguration<Country>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Country> builder)
        {
            builder
            .Property(a => a.Name)
            .HasMaxLength(255);

            builder.HasMany(e => e.Soldiers)
                   .WithOne(e => e.Country)
                   .HasForeignKey(e => e.CountryId)
                   .IsRequired();
        }
    }
}
