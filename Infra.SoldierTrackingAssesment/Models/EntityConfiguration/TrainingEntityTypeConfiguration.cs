using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public class TrainingEntityTypeConfiguration : BaseEntityTypeConfiguration<Training>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Training> builder)
        {
            builder.HasMany(e => e.Data)
                   .WithOne(e => e.Training)
                   .HasForeignKey(e => e.TrainingId)
                   .IsRequired();

            builder
                .HasMany(e => e.Soldiers)
                .WithMany(e => e.Trainings);
        }
    }
}
