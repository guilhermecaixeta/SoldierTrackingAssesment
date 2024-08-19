using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class TrainingDataEntityTypeConfiguration : BaseEntityTypeConfiguration<TrainingData>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TrainingData> builder)
        {
            builder
                .HasIndex(e => new { e.SensorId, e.SoldierId, e.TrainingId });

            builder.HasOne(e => e.Soldier)
                .WithMany()
                .HasForeignKey(e => e.SoldierId);

            builder.HasOne(e => e.Sensor)
                .WithMany()
                .HasForeignKey(e => e.SensorId)
                .IsRequired();

            builder.HasOne(e => e.Training)
                .WithMany(e => e.Data)
                .HasForeignKey(e => e.TrainingId)
                .IsRequired();
        }
    }
}
