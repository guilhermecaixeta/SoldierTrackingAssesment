using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class GeolocalizationEntityTypeConfiguration : IEntityTypeConfiguration<GeolocalizationSensor>
    {
        public void Configure(EntityTypeBuilder<GeolocalizationSensor> builder)
        {
            builder.HasMany(e => e.Locations)
                .WithOne(e => e.Sensor)
                .HasForeignKey(e => e.SensorId)
                .IsRequired();
        }
    }
}
