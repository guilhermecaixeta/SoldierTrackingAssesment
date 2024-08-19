using Infra.SoldierTrackingAssesment.Models;
using Infra.SoldierTrackingAssesment.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infra.SoldierTrackingAssesment
{
    public class SoldierTrackingAssesmentContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<TrainingData> TrainingDatas { get; set; }
        public DbSet<GeolocalizationSensor> GeolocalizationSensors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public SoldierTrackingAssesmentContext(DbContextOptions<SoldierTrackingAssesmentContext> options)
        : base(options)
        { }

        public SoldierTrackingAssesmentContext()
        { }

        #region Required
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SoldierTrackingAssesment_development;ConnectRetryCount=0;Password=password123!;User Id=sa;TrustServerCertificate=True;",
                builder => builder.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CountryEntityTypeConfiguration).Assembly);
        }
        #endregion

        public void TruncateAllTables()
        {
            var tableNames = Model.GetEntityTypes()
                                  .Select(t => t.GetTableName())
                                  .Distinct()
                                  .ToList();

            foreach (var tableName in tableNames)
            {
                Database.ExecuteSqlRaw($"DELETE FROM [{tableName}];");
            }
        }
    }
}
