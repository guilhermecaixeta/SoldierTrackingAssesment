using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class LocationEntityTypeConfiguration : BaseEntityTypeConfiguration<Location>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Location> builder)
        {
            builder.HasOne(e => e.Sensor)
                .WithMany()
                .HasForeignKey(e => e.SensorId)
                .IsRequired();
        }
    }
}
