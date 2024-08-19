using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public abstract class BaseSensorEntityTypeConfiguration<TSensor> : BaseEntityTypeConfiguration<TSensor>
        where TSensor : BaseSensor
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TSensor> builder)
        {
            builder
                .UseTpcMappingStrategy();

            builder
                .Property(e => e.Name)
                .HasMaxLength(255);

            builder
                .Property(e => e.Type)
                .HasMaxLength(255);
        }
    }
}
