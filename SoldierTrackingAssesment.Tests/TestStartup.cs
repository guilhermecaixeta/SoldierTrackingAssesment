using Infra.SoldierTrackingAssesment;
using Microsoft.EntityFrameworkCore;

namespace SoldierTrackingAssesment.Tests
{
    public class TestStartup : IDisposable
    {
        protected readonly SoldierTrackingAssesmentContext dbContext;

        public TestStartup()
        {
            var contextOptions = new DbContextOptionsBuilder<SoldierTrackingAssesmentContext>()
                    .UseSqlServer(@"Server=localhost;Database=SoldierTracking_test;ConnectRetryCount=0;Password=password123!;User Id=sa;TrustServerCertificate=True;",
                    builder => builder.UseNetTopologySuite())
                    .Options;

            dbContext = new SoldierTrackingAssesmentContext(contextOptions);

            dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            dbContext.TruncateAllTables();
            dbContext.Dispose();
        }
    }
}
