using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SoldierTrackingAssesment.Models.EntityConfiguration
{
    public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
            where TEntity : BaseEntity
    {
        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // To make easier and more efficient queries.
            builder
                .HasKey(e => e.Id);

            builder
                .HasIndex(e => new { e.Guid })
                .IsUnique();

            ConfigureEntity(builder);
        }
    }
}
